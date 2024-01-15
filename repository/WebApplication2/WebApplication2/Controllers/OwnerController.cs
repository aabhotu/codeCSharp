using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners() {
            try {
                var owners = _repository.Owner.GetAllOwners();

                _logger.LogInfo("It's will be okk");
                var ownerResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownerResult);
            }
            catch (Exception ex) {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if (owner is null)
                {
                    _logger.LogError($"Not found user with id: {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"User with id: {id}");
                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetail(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerWithDetail(id);
                if (owner == null)
                {
                    _logger.LogError($"Not found user with id: {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"User with id: {id}");
                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateOwner([FromBody] OwnerForCreateDto owner)
        {
            try
            {
                if(owner is null)
                {
                    _logger.LogError($"Object sent is null");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid");
                    return BadRequest("Invalid");
                }
                var ownerEntity = _mapper.Map<Owner>(owner);
                _repository.Owner.CreateOwner(ownerEntity);
                _repository.Save();

                var ownerCreate = _mapper.Map<OwnerDto>(ownerEntity);
                return CreatedAtRoute("OwnerById", new {id = ownerCreate.Id}, ownerCreate);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody]OwnerForUpdateDto owner)
        {
            try
            {
                if (owner is null)
                {
                    _logger.LogError($"Object sent is null");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid");
                    return BadRequest("Invalid");
                }
                var ownerEntity = _repository.Owner.GetOwnerById(id);
                if(ownerEntity is null)
                {
                    _logger.LogError($"Don't have owner with id {id}");
                    return NotFound();
                }
                _mapper.Map(owner, ownerEntity);
                _repository.Owner.UpdateOwner(ownerEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex) {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if (owner is null)
                {
                    _logger.LogError($"Don't have owner with id {id}");
                    return NotFound();
                }
                if (_repository.Account.AccountsByOwner(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }
                _repository.Owner.DeleteOwner(owner);
                _repository.Save();
                return NoContent() ;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
