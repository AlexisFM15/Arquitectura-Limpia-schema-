using ArquitecturaLimpia.Domain;
using ArquitecturaLimpia.Domain.DTO;
using ArquitecturaLimpia.Infrastructure.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        protected CategoriaRepository _repository;
        protected IMapper _mapper;
        private readonly  ILogger<CategoriaRepository> _logger;
            
        public CategoriaController(CategoriaRepository repository, IMapper mapper, ILogger<CategoriaRepository> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) {
            _logger.LogInformation("Realizando el getByID.");
            
            try
            {
            var category = await _repository.GetById(id);
            var categoryDTO = _mapper.Map<CategoriaDTO>(category);
                if (category == null) { 
                    _logger.LogInformation("Usuario no existe");
                return NotFound();
                }
                _logger.LogInformation("Realizdo con exito." + category.Nombre );
                return Ok(categoryDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al realizar la tarea.");
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoriaDTO entitiy)
        {
            try
            {
                var result = await _repository.Add(_mapper.Map<Categoria>(entitiy));
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al realizar la transaccion.");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idEntity)
        {
            try 
            {
               await _repository.Delete(idEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al Borrar");
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            try
            {
                var result = await _repository.List();
                var categoriaDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(result.ToList());
                return Ok(categoriaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
