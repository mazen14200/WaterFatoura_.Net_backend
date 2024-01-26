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
    public class SubscriberController : ControllerBase
    {
        private readonly IBaseRepository<Subscriber_File> _SubscriberRepository;
        private readonly IMapper _mapper;

        public SubscriberController(
            IBaseRepository<Subscriber_File> SubscriberRepository,
            IMapper mapper,
            IBaseRepository<Default_Slice_Values> DSValues_Repository)
        {
            _SubscriberRepository = SubscriberRepository;
            _mapper = mapper;
        }



        //Get  https://localhost:44394/api/Subscriber
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSubscribers()
        {
            IEnumerable<Subscriber_File> Subscribers = await _SubscriberRepository.GetAllAsync();
            var SubscribersDTOMapped = _mapper.Map<IEnumerable<DTO_Subscriber_File>>(Subscribers);
            return Ok(SubscribersDTOMapped);
        }

        //Get https://localhost:44394/api/Subscriber/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleSubscriber([FromRoute] string id)
        {
            try
            {

                var Subscriber = await _SubscriberRepository.GetSingleByIdAsync(id);

                if (Subscriber != null)
                {
                    var SubscriberDTOMapped = _mapper.Map<DTO_Subscriber_File>(Subscriber);
                    return Ok(SubscriberDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }

        }

        //post  https://localhost:44394/api/Subscriber
        [HttpPost]
        //[Route("")]
        public async Task<IActionResult> AddSingleSubscriber([FromBody] DTO_Subscriber_File Subscriber_request)
        {
            try
            {
                Subscriber_File? exist_id = await _SubscriberRepository.GetSingleByIdAsync(Subscriber_request.Id);
                if ( exist_id != null )
                {
                    return Ok("you already has account - this ID is used before please try another one");
                }
                var SubscriberMapped = _mapper.Map<Subscriber_File>(Subscriber_request);
                

                string Subscriber_1 = await _SubscriberRepository.AddSingle_Async(SubscriberMapped);
                if (Subscriber_1 == "Successfuly Added")
                {
                    var SubscriberDTOMapped = _mapper.Map<DTO_Subscriber_File>(SubscriberMapped);

                    return Ok(SubscriberDTOMapped);

                }

                return Ok(NotFound());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }
        }


        //Delete https://localhost:44394/api/Subscriber/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSingelSubscriber([FromRoute] string id)
        {
            try
            {
                var Existing = await _SubscriberRepository.GetSingleByIdAsync(id);
                string delete = await _SubscriberRepository.Delete_Single_Async(id);
                if (Existing != null && delete == "Successfuly Deleted")
                {
                    var response = _mapper.Map<DTO_Subscriber_File>(Existing);
                    return Ok(response);

                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(NotFound());
        }



        //put https://localhost:44394/api/Subscriber
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSingelSubscriber([FromRoute] string id, [FromBody] DTORequest_Subscriber_File Subscriber_Request)
        {
            try
            {
                var Existing = await _SubscriberRepository.GetSingleByIdAsync(id);
                if (Existing != null)
                {

                    var SubscriberMapped = _mapper.Map<Subscriber_File>(Subscriber_Request);
                    SubscriberMapped.Id = id;
                    //return Ok(SubscriberMapped);
                    string updated_return = await _SubscriberRepository.Update_Async(SubscriberMapped, id);
                    if (updated_return == "Successfuly updated")
                    {
                        var response = _mapper.Map<DTO_Subscriber_File >(SubscriberMapped);
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
