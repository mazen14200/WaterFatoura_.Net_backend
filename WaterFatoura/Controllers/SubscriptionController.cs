using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Globalization;
using RepositoryLayer.Contract_interfaces;
using DomainLayer.models;
using DomainLayer.DTO;
using DomainLayer.DTO.Requests;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper;

namespace WaterFatoura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly IBaseRepository<Subscription_File> _subscriptionRepository;
        private readonly IBaseRepository<Invoices> _InvoicesRepository;
        private readonly IBaseRepository<Subscriber_File> _SubscriberRepository;
        private readonly IBaseRepository<Real_Estate_Types> _RETypes_Repository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Default_Slice_Values> _DSValues_Repository;

        public SubscriptionController(IBaseRepository<Subscription_File> SubscriptionRepository,
            IBaseRepository<Invoices> InvoicesRepository,
            IBaseRepository<Subscriber_File> SubscriberRepository,
            IBaseRepository<Real_Estate_Types> RETypes_Repository,
            IMapper mapper,
            IBaseRepository<Default_Slice_Values> DSValues_Repository)
        {
            _subscriptionRepository = SubscriptionRepository;
            _InvoicesRepository = InvoicesRepository;
            _SubscriberRepository = SubscriberRepository;
            _RETypes_Repository = RETypes_Repository;
            _mapper = mapper;
            _DSValues_Repository = DSValues_Repository;
        }
        // GET: SubscriptionController
        //[HttpGet]
        //public IActionResult Index()
        //{

        //    DateOnly date = new DateOnly();
        //    string na = "";
        //    List<string> lii = new List<string>();

        //    na = DateTime.Now.ToString();
        //    lii.Add(na);

        //    na = DateTime.Now.ToString("dd/MM/yy");
        //    lii.Add(na);

        //    na = DateTime.Now.AddDays(1).ToString("dd/MM/yy");
        //    lii.Add(na);

        //    na = DateTime.Now.AddDays(1).AddMonths(-1).ToString("dd/MM/yy");
        //    lii.Add(na);

        //    na = "16/12/23".Replace("/","-").Replace(".", "-").Replace("|", "-").ToString();
        //    lii.Add(na);

        //    na = "16|12|23".Replace("/", "-").Replace(".", "-").Replace("|", "-").ToString();
        //    lii.Add(na);

        //    na = "16 12 23".Replace("/", "-").Replace(".", "-").Replace("|", "-").Replace(" ", "-").ToString();
        //    lii.Add(na);

        //    // اهم حاجة MM كابيتال لـأن
        //    // MM ---> month  كابيتال
        //    // mm ---> minute  سمول 
        //    string sp_Date;
        //    int sp_id;
        //    string fruits = "23-2-1";
        //    char separator = '-';
        //    string[] fruitArray = fruits.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        //    sp_Date = fruitArray[0] + "-" + fruitArray[1];
        //    int number = Int16.Parse(fruitArray[2], CultureInfo.InvariantCulture);
        //    sp_id = number;

        //    lii.Add(sp_Date);
        //    lii.Add(sp_id.ToString());
        //    return Ok(lii);
        //}


        //Get  https://localhost:44394/api/Subscription
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSubscription()
        {
            IEnumerable<Subscription_File> Subscriptions = await _subscriptionRepository.GetAllAsync();
            var SubscriptionsDTOMapped = _mapper.Map<IEnumerable<DTO_Subscription_File>>(Subscriptions);
            return Ok(SubscriptionsDTOMapped);
        }

        //Get https://localhost:44394/api/Subscription/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleSubscription([FromRoute] string id)
        {
            try
            {

                var Subscription = await _subscriptionRepository.GetSingleByIdAsync(id);

                if (Subscription != null)
                {
                    var SubscriptionDTOMapped = _mapper.Map<DTO_Subscription_File>(Subscription);
                    return Ok(SubscriptionDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }

        }

        //post  https://localhost:44394/api/Subscription
        [HttpPost]
        //[Route("")]
        public async Task<IActionResult> AddSingleSubscription([FromBody] DTORequest_Subscription_File Subscription_request)
        {
            try
            {
                var SubscriptionMapped = _mapper.Map<Subscription_File>(Subscription_request);
                string id = _subscriptionRepository.GenerateID_Subscription();
                if (id != "")
                {
                    SubscriptionMapped.NO_Subscription = id;

                    string Subscription_1 = await _subscriptionRepository.AddSingle_Async(SubscriptionMapped);
                    if (Subscription_1 == "Successfuly Added")
                    {
                        var SubscriptionDTOMapped = _mapper.Map<DTO_Subscription_File>(SubscriptionMapped);

                        return Ok(SubscriptionDTOMapped);

                    }
                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }


        //Delete https://localhost:44394/api/Subscription/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSingelSubscription([FromRoute] string id)
        {
            try
            {
                var Existing = await _subscriptionRepository.GetSingleByIdAsync(id);
                string delete = await _subscriptionRepository.Delete_Single_Async(id);
                if (Existing != null && delete == "Successfuly Deleted")
                {
                    var response = _mapper.Map<DTO_Subscription_File>(Existing);
                    return Ok(response);

                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(NotFound());
        }



        //put https://localhost:44394/api/Subscription
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSingelSubscription([FromRoute] string id, [FromBody] DTORequest_Subscription_File Subscription_Request)
        {
            try
            {
                var Existing = await _subscriptionRepository.GetSingleByIdAsync(id);
                if (Existing != null)
                {

                    var SubscriptionMapped = _mapper.Map<Subscription_File>(Subscription_Request);
                    SubscriptionMapped.NO_Subscription = id;
                    //return Ok(SubscriptionMapped);
                    string updated_return = await _subscriptionRepository.Update_Async(SubscriptionMapped, id);
                    if (updated_return == "Successfuly updated")
                    {
                        var response = _mapper.Map<DTO_Subscription_File>(SubscriptionMapped);
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


        //Get  https://localhost:44394/api/Subscription/GenerateID
        [HttpGet]
        [Route("GenerateID")]
        public async Task<IActionResult> Get_Generated_ID()
        {
            List<string> li = new List<string>();

            try
            {
                string id = _subscriptionRepository.GenerateID_Subscription();
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
                li.Add(ex.Message);
                return Ok(li);
            }
        }
    }
}
