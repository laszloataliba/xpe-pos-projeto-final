using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPE.Desafio.Final5.API.Model.Domains;
using XPE.Desafio.Final5.API.Model.Services.Interfaces;

namespace XPE.Desafio.Final5.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpPost,
         Route("products"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                await productService.Create(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet,
         Route("products"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await productService.GetAll();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet,
         Route("products/{product-id:guid}"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute(Name = "product-id")] Guid productId)
        {
            try
            {
                var product = await productService.GetById(productId);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet,
         Route("products/{product-name}"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByName([FromRoute(Name = "product-name")] string productName)
        {
            try
            {
                var products =
                    await productService.GetItemsByName(x => EF.Functions.Like(x.Name, $"%{productName}%"));

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet,
         Route("products/total"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Total()
        {
            try
            {
                var products = (await productService.GetAll()).Count;

                return Ok(new { Quantity = products });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut,
         Route("products"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                await productService.Update(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete,
         Route("products/{product-id:guid}"),
         Consumes("application/json"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute(Name = "product-id")] Guid productId)
        {
            try
            {
                await productService.Delete(productId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
