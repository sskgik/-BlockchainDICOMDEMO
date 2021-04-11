using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Miyabi;
using Miyabi.NFT.Client;
using Miyabi.NFT.Models;
using Miyabi.Cryptography;
using Miyabi.Common.Models;
using Miyabi.ClientSdk;
using Miyabi.Serialization.Json;
using System.Text.Json;
using System.Diagnostics;
using System.ComponentModel;
using WalletService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DICOMNFTController : ControllerBase
    {
        
        // GET: api/<DICOMNFTController>/5
        [HttpGet]
        public async Task<string> GetTokenownerKey([FromQuery] string  publickey)
        {
            NFTTypesRegisterer.RegisterTypes();
            WAction walletservice = new WAction();
            var result = await walletservice.ShowNFTOwner("NFTtest", publickey); 
            return  result;
        }


        // POST api/<DICOMNFTController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
