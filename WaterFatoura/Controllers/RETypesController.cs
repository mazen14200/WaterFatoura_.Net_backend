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
    public class RETypesController : ControllerBase
    {
        private readonly IBaseRepository<Subscription_File> _subscriptionRepository;
        private readonly IBaseRepository<Invoices> _invoicesRepository;
        private readonly IBaseRepository<Subscriber_File> _SubscriberRepository;
        private readonly IBaseRepository<Real_Estate_Types> _RETypes_Repository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Default_Slice_Values> _DSValues_Repository;

        public RETypesController(IBaseRepository<Subscription_File> SubscriptionRepository,
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

        //Get  https://localhost:44394/api/RETypes
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll_RETypes()
        {
            IEnumerable<Real_Estate_Types> RETypes = await _RETypes_Repository.GetAllAsync();
            var RETypesDTOMapped = _mapper.Map<IEnumerable<DTO_Real_Estate_Types>>(RETypes);
            return Ok(RETypesDTOMapped);
        }

        //Get https://localhost:44394/api/RETypes/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingle_REType([FromRoute] char id)
        {
            try
            {

                var REType = await _RETypes_Repository.GetSingleById_Char_Async(id);

                if (REType != null)
                {
                    var RETypeDTOMapped = _mapper.Map<DTO_Real_Estate_Types>(REType);
                    return Ok(RETypeDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }

        }

        //post  https://localhost:44394/api/RETypes
        [HttpPost]
        //[Route("")]
        public async Task<IActionResult> AddSingle_RETypes(DTO_Real_Estate_Types REType_request)
        {
            try
            {
                Real_Estate_Types? exist_id = await _RETypes_Repository.GetSingleById_Char_Async(REType_request.Code);
                if (exist_id != null)
                {
                    return Ok("this ID is used before please try another one");
                }
                var RETypeMapped = _mapper.Map<Real_Estate_Types>(REType_request);


                string REType_1 = await _RETypes_Repository.AddSingle_Async(RETypeMapped);
                if (REType_1 == "Successfuly Added")
                {
                    var RETypeDTOMapped = _mapper.Map<DTO_Real_Estate_Types>(RETypeMapped);

                    return Ok(RETypeDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }


        //Delete https://localhost:44394/api/RETypes/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSingel_RETypes([FromRoute] char id)
        {
            //char x = id[0];
            try
            {
                Real_Estate_Types? Existing = await _RETypes_Repository.GetSingleById_Char_Async(id);
                string delete = await _RETypes_Repository.Delete_Single_Char_Async(id);
                if (Existing != null && delete == "Successfuly Deleted")
                {
                    var response = _mapper.Map<DTO_Real_Estate_Types>(Existing);
                    return Ok(response);

                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(NotFound());
        }



        //put https://localhost:44394/api/RETypes
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSingel_RETypes([FromRoute] char id, [FromBody] DTORequest_Real_Estate_Types REType_Request)
        {
            try
            {
                var Existing = await _RETypes_Repository.GetSingleById_Char_Async(id);
                if (Existing != null)
                {

                    var RETypeMapped = _mapper.Map<Real_Estate_Types>(REType_Request);
                    RETypeMapped.Code = id;
                    //return Ok(RETypeMapped);
                    string updated_return = await _RETypes_Repository.Update_Char_Async(RETypeMapped, id);
                    if (updated_return == "Successfuly updated")
                    {
                        var response = _mapper.Map<DTO_Real_Estate_Types>(RETypeMapped);
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
