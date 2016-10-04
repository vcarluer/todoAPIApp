using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoAPIApp.Models;
using System.IO;
using Newtonsoft.Json;

namespace todoAPIApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
	private readonly ILogger<TodoController> _logger;
	public TodoController(ILogger<TodoController> logger)
	{
		this._logger = logger;	
	}

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]TodoItem item)
        {
		this._logger.LogInformation("POST received Text: " + item.Text);
		var id = Guid.NewGuid();
		this._logger.LogInformation("New ID: {0}", id.ToString());
		item.Id = id;
		string json = JsonConvert.SerializeObject(item);
		if (!Directory.Exists("./data"))
		{
			Directory.CreateDirectory("./data");
		}

		System.IO.File.WriteAllText("./data/" + id.ToString(), json);

		return item.Text;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
