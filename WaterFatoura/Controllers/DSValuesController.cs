using DomainLayer.models;
using DomainLayer.DTO;
using DomainLayer.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Contract_interfaces;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterFatoura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSValuesController : ControllerBase
    {
        private readonly IBaseRepository<Subscription_File> _subscriptionRepository;
        private readonly IBaseRepository<Invoices> _invoicesRepository;
        private readonly IBaseRepository<Subscriber_File> _SubscriberRepository;
        private readonly IBaseRepository<Real_Estate_Types> _DSValuess_Repository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Default_Slice_Values> _DSValues_Repository;

        public DSValuesController(IBaseRepository<Subscription_File> SubscriptionRepository,
            IBaseRepository<Invoices> InvoicesRepository,
            IBaseRepository<Subscriber_File> SubscriberRepository,
            IBaseRepository<Real_Estate_Types> DSValuess_Repository,
            IMapper mapper,
            IBaseRepository<Default_Slice_Values> DSValues_Repository)
        {
            _subscriptionRepository = SubscriptionRepository;
            _invoicesRepository = InvoicesRepository;
            _SubscriberRepository = SubscriberRepository;
            _DSValuess_Repository = DSValuess_Repository;
            _mapper = mapper;
            _DSValues_Repository = DSValues_Repository;
        }



        //Get  https://localhost:44394/api/DSValues
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll_DSValues()
        {
            IEnumerable<Default_Slice_Values> DSValuess = await _DSValues_Repository.GetAllAsync();
            var DSValuessDTOMapped = _mapper.Map<IEnumerable<DTO_Default_Slice_Values>>(DSValuess);
            return Ok(DSValuessDTOMapped);
        }

        //Get https://localhost:44394/api/DSValues/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingle_DSValues([FromRoute] char id)
        {
            try
            {

                var DSValues = await _DSValues_Repository.GetSingleById_Char_Async(id);

                if (DSValues != null)
                {
                    var DSValuesDTOMapped = _mapper.Map<DTO_Default_Slice_Values>(DSValues);
                    return Ok(DSValuesDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }

        }

        //post  https://localhost:44394/api/DSValues
        [HttpPost]
        //[Route("")]
        public async Task<IActionResult> AddSingle_DSValues(DTO_Default_Slice_Values DSValues_request)
        {
            try
            {
                Default_Slice_Values? exist_id = await _DSValues_Repository.GetSingleById_Char_Async(DSValues_request.Code);
                if (exist_id != null)
                {
                    return Ok("this ID is used before please try another one");
                }
                var DSValuesMapped = _mapper.Map<Default_Slice_Values>(DSValues_request);


                string DSValues_1 = await _DSValues_Repository.AddSingle_Async(DSValuesMapped);
                if (DSValues_1 == "Successfuly Added")
                {
                    var DSValuesDTOMapped = _mapper.Map<DTO_Default_Slice_Values>(DSValuesMapped);

                    return Ok(DSValuesDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }


        //Delete https://localhost:44394/api/DSValues/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSingel_DSValues([FromRoute] char id)
        {
            //char x = id[0];
            try
            {
                Default_Slice_Values? Existing = await _DSValues_Repository.GetSingleById_Char_Async(id);
                string delete = await _DSValues_Repository.Delete_Single_Char_Async(id);
                if (Existing != null && delete == "Successfuly Deleted")
                {
                    var response = _mapper.Map<DTO_Default_Slice_Values>(Existing);
                    return Ok(response);

                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(NotFound());
        }



        //put https://localhost:44394/api/DSValues
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSingel_DSValues([FromRoute] char id, [FromBody] DTORequest_Default_Slice_Values DSValues_Request)
        {
            try
            {
                var Existing = await _DSValues_Repository.GetSingleById_Char_Async(id);
                if (Existing != null)
                {

                    var DSValuesMapped = _mapper.Map<Default_Slice_Values>(DSValues_Request);
                    DSValuesMapped.Code = id;
                    //return Ok(DSValuesMapped);
                    string updated_return = await _DSValues_Repository.Update_Char_Async(DSValuesMapped, id);
                    if (updated_return == "Successfuly updated")
                    {
                        var response = _mapper.Map<DTO_Default_Slice_Values>(DSValuesMapped);
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


    }
}
