using DomainLayer.models;
using DomainLayer.DTO;
using DomainLayer.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Contract_interfaces;
using AutoMapper.Execution;
using System.Globalization;
using AutoMapper;

namespace WaterFatoura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IBaseRepository<Subscription_File> _subscriptionRepository;
        private readonly IBaseRepository<Invoices> _invoicesRepository;
        private readonly IBaseRepository<Subscriber_File> _SubscriberRepository;
        private readonly IBaseRepository<Real_Estate_Types> _RETypes_Repository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Default_Slice_Values> _DSValues_Repository;

        public InvoicesController(IBaseRepository<Subscription_File> SubscriptionRepository,
            IBaseRepository<Invoices> InvoicesRepository,
            IBaseRepository<Subscriber_File> SubscriberRepository,
            IBaseRepository<Real_Estate_Types> RETypes_Repository,
            IMapper mapper,
            IBaseRepository<Default_Slice_Values> DSValues_Repository)
        {
            _subscriptionRepository = SubscriptionRepository;
            _invoicesRepository = InvoicesRepository;
            _SubscriberRepository = SubscriberRepository;
            _RETypes_Repository = RETypes_Repository;
            _mapper = mapper;
            _DSValues_Repository = DSValues_Repository;
        }

        //Get  https://localhost:44394/api/Invoices
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInvoices()
        {
            IEnumerable<Invoices> Invoices = await _invoicesRepository.GetAllAsync();
            var InvoicesDTOMapped = _mapper.Map<IEnumerable<DTO_Invoices>>(Invoices);
            return Ok(InvoicesDTOMapped);
        }

        //Get https://localhost:44394/api/Invoices/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleInvoice([FromRoute]string id)
        {
            try
            {
            
                var Invoice = await _invoicesRepository.GetSingleByIdAsync(id);
                
                if (Invoice != null)
                {
                    var InvoiceDTOMapped = _mapper.Map<DTO_Invoices>(Invoice);
                    return Ok(InvoiceDTOMapped);

                }
                
            return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }

        }

        //post  https://localhost:44394/api/Invoices
        [HttpPost]
        //[Route("")]
        public async Task<IActionResult> AddSingleInvoice([FromBody] DTORequest_Invoices invoice_request)
        {
            try
            {
                var invoiceMapped = _mapper.Map<Invoices>(invoice_request);
                //Invoices invoiceMapped = new Invoices {
                //    Is_There_Sanitation = invoice_request.Is_There_Sanitation,
                //    FK_Real_Estate_Types_id = invoice_request.FK_Real_Estate_Types_id,
                //    FK_Subscription_No_sp_id = invoice_request.FK_Subscription_No_sp_id,
                //    Total_Invoice = invoice_request.Total_Invoice,
                //    Amount_Consumption_Amount = invoice_request.Amount_Consumption_Amount,
                //    Consumption_Value = invoice_request.Consumption_Value,
                //    Current_Consumption_Amount = invoice_request.Current_Consumption_Amount,
                //    Date = invoice_request.Date,
                //    FK_Subscriber_No = invoice_request.FK_Subscriber_No,
                //    FK_Subscription_No_sp_Date = invoice_request.FK_Subscription_No_sp_Date,
                //    From = invoice_request.From,
                //    Previous_Consumption_Amount = invoice_request.Previous_Consumption_Amount,
                //    Reasons = invoice_request.Reasons,
                //    Service_Free = invoice_request.Service_Free,
                //    Tax_Rate = invoice_request.Tax_Rate,
                //    Tax_Value = invoice_request.Tax_Value,
                //    To = invoice_request.To,
                //    Total_Bill = invoice_request.Total_Bill,
                //    Wastewater_Consumption_Value = invoice_request.Wastewater_Consumption_Value,
                //    year = invoice_request.year
                //};
                string id = _invoicesRepository.GenerateID_Invoices();
                if (id != "")
                {
                    invoiceMapped.NO_Invoice = id;

                    string Invoice_1 = await _invoicesRepository.AddSingle_Async(invoiceMapped);
                    if (Invoice_1 == "Successfuly Added")
                     {
                        var invoiceDTOMapped = _mapper.Map<DTO_Invoices>(invoiceMapped);

                        return Ok(invoiceDTOMapped);

                    }
                }
                
                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }


        //Delete https://localhost:44394/api/Invoices/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSingelInvoice([FromRoute]string id)
        {
            try
            {
                var Existing = await _invoicesRepository.GetSingleByIdAsync(id);
                string delete = await _invoicesRepository.Delete_Single_Async(id);
                if(Existing != null && delete == "Successfuly Deleted")
                {
                    var response = _mapper.Map<DTO_Invoices>(Existing);
                    return Ok(response);

                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(NotFound());
        }



        //put https://localhost:44394/api/Invoices
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSingelInvoice([FromRoute] string id, [FromBody]DTORequest_Invoices invoice_Request)
        {
            try
            {
                var Existing = await _invoicesRepository.GetSingleByIdAsync(id);
                if (Existing != null)
                {

                var invoceMapped = _mapper.Map<Invoices>(invoice_Request);
                invoceMapped.NO_Invoice = id;
                    //return Ok(invoceMapped);
                string updated_return = await _invoicesRepository.Update_Async(invoceMapped, id);
                if (updated_return == "Successfuly updated")
                {
                    var response = _mapper.Map<DTO_Invoices>(invoceMapped);
                    return Ok(response);

                }
                return Ok(updated_return);
                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(NotFound());
        }


        //Get  https://localhost:44394/api/Invoice/GenerateID
        [HttpGet]
        [Route("GenerateID")]
        public async Task<IActionResult> Get_Generated_ID()
        {
            List<string> li = new List<string>();
            try
            {
                string id = _invoicesRepository.GenerateID_Invoices();
                if (id != "" && id != null)
                {
                    li.Add(id);
                    return Ok(li);

                }

                li.Add("");
                return Ok(li);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }

        //Get  https://localhost:44394/api/Invoice/Date_Generated
        [HttpGet]
        [Route("Date_Generated/{date}")]
        public async Task<IActionResult> Get_Generated_Date([FromRoute]DateTime date)
        {
            List<string> li = new List<string>();
            try
            {

                if (date != null)
                {
                    string na = date.AddDays(-1).AddMonths(1).ToString("dd/MM/yyyy");

                    na = na.Replace("/", "-").Replace(".", "-").Replace("|", "-").Replace(" ", "-").ToString();

                    li.Add(na);
                    return Ok(li);

                }
                li.Add("");
                return Ok(li);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }

    }
}
