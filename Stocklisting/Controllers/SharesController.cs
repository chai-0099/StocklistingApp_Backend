using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Stocklisting.Model;
using Stocklisting.Repsository;

namespace Stocklisting.Controllers
{

  //add the annotations ApiController, Route
  [ApiController]
  [Route("api/[controller]")]
  public class SharesController : ControllerBase
  {
    //add the ISharesRepo as a variable
    private readonly ISharesRepo sRepo;


    //add the constructor to the class SharesController
    public SharesController(ISharesRepo sharesRepo)
    {
      sRepo = sharesRepo;
    }

    //add the methods to the class SharesController

    [Route("share")]
    //add the annotation HttpPut to the method addShareData
    [HttpPut]


    //add the method addShareData to the class SharesController
    public IActionResult addShareData(Shares shares)
    {
      sRepo.createShares(shares);
      return Ok(shares);
    }

    //add the annotation HttpGet to the method getShareData
    [Route("share")]
    [HttpGet]
    public async Task<IActionResult> getShareData()
    {

      return Ok(sRepo.allShares());
    }

    //add the annotation HttpGet to the method getSharesData
    [Route("shares")]
    [HttpGet]
    public async Task<IActionResult> getSharesData(String country)
    {

      /*Call an external api with new HttpClient()*/
      var client = new HttpClient();
      //add a api key as a response header to the request 
      var response = await client.GetAsync("https://api.twelvedata.com/stocks?country=" + country);
      //add a responseString variable to store the response as a ReadAsStringAsync
      string responseString = await response.Content.ReadAsStringAsync();
      //add a variable shares to store the responseString as a Deserialize
      var shares = JsonSerializer.Deserialize<Data>(responseString);
      return Ok(shares.data);
    }

    //add the annotation HttpGet to the method getTimeSeriesSharesData
    [Route("timeseriesshares")]
    [HttpGet]
    //add the method getTimeSeriesSharesData to the class SharesController
    public async Task<IActionResult> getTimeSeriesSharesData(String symbol)
    {
      /*Call an external api with new HtppClient()*/


      var client = new HttpClient();
      //add a api key as a response as getAsync
      var response = await client.GetAsync("https://api.twelvedata.com/time_series?symbol=" + symbol + "&interval=1min&apikey=7510425dfb0b4bbf9440290467ce2a7f");
      //add a responseString variable to store the response as a ReadAsStringAsync
      var responseString = await response.Content.ReadAsStringAsync();

      return Ok(responseString);

    }
  }
}
