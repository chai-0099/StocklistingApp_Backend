using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Stocklisting.Exception;
using Stocklisting.Model;
using Stocklisting.Repsository;

namespace Stocklisting.Controllers
{

    //add the annotation of API controller
    [ApiController]
    //add the annotation of route
    [Route("api/[controller]")]
  public class SharesController : ControllerBase
  {

        //add the ISharesRepo interface
        private readonly ISharesRepo repo;

        //add the constructor to inject the ISharesRepo interface
        public SharesController(ISharesRepo repo)
        {
            this.repo = repo;
        }


        //add the http put method

        [HttpPut]
        //add the annotation of route
        [Route("share")]
        //add the method to create a new share
        public IActionResult CreateShares(Shares shares)
        {
            //add a try catch block with SharesAlreadyExistsException
            try
            {
                //add the if statement to check if the repo create shares method is true
                if (repo.CreateShares(shares))
                {
                    //add the return statement to return the created at action
                    return CreatedAtAction(nameof(CreateShares), shares);
                }
                else
                {
                    //add the return statement to return the bad request
                    return BadRequest();
                }
            }
            catch (SharesAlreadyExistsException)
            {
                //add the return statement to return the conflict
                return Conflict();
            }
        }

        //add teh http get method to get all shares
        [HttpGet]
        //add the annotation of route
        [Route("share")]
        //add teh method with async  task
        public async Task<IActionResult> GetAllShares()
        {
            //add the try catch block with SharesNotFoundException
            try
            {
                //add the variable to get all shares
                var shares = await Task.FromResult(repo.GetAllShares());
                //add the if statement to check if the shares is not null
                if (shares != null)
                {
                    //add the return statement to return the ok
                    return Ok(shares);
                }
                else
                {
                    //add the return statement to return the not found
                    return NotFound();
                }
            }
            catch (SharesNotFoundException)
            {
                //add the return statement to return the not found
                return NotFound();
            }
        }

        //add the annotation of http get method to the method GetShares data
        [HttpGet]
        //add the annotation of route
        [Route("shares")]

        //add the method async task to get the shares data
        public async Task<IActionResult> GetShares(String country)
        {
            //add the try catch block with SharesNotFoundException
            try
            {
                //Call the new instance of the HttpClient
                var client = new HttpClient();
                //add a api call as a respose variable
                var response = await client.GetAsync("https://api.twelvedata.com/stocks?country=" + country);
                //add a responseString variable to get the response content  using ReadAsStringAsync
                var responseString = await response.Content.ReadAsStringAsync();
                //add a variable shares to store the response string using Deserialize
                var shares = JsonSerializer.Deserialize<Data>(responseString);
                return Ok(shares.data);

            }
            catch (SharesNotFoundException)
            {
                //add the return statement to return the not found
                return NotFound();
            }
        }


        //add the annotation of http get method to the method GetShares data
        [HttpGet]
        //add the annotation of route
        [Route("timeseriesshares")]
        //add the method async task to get the shares data
        public async Task<IActionResult> GetTimeSeriesShares(String symbol)
        {
            //add the try catch block with SharesNotFoundException
            try
            {
                //Add  new instance of the HttpClient
                var client = new HttpClient();
                //add a api call as a respose variable
                var response = await client.GetAsync("https://api.twelvedata.com/time_series?symbol= + symbol + &interval=1min&apikey=7510425dfb0b4bbf9440290467ce2a7f");
                //add a responseString variable to get the response content  using ReadAsStringAsync
                var responseString = await response.Content.ReadAsStringAsync();

                return Ok(responseString);
               

            }
            catch (SharesNotFoundException)
            {
                //add the return statement to return the not found
                return NotFound();
            }
        }   
    
  }
}

