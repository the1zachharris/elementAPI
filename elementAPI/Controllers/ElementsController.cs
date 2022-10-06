using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using elementAPI.models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace elementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ElementsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Elements
        [HttpGet]
        public List<Element> GetElements()
        {

            var rootPath = _hostingEnvironment.ContentRootPath; //get the root path

            var fullPath = Path.Combine(rootPath, "MOCK_DATA.json"); //combine the root path with that of our json file

            var data = System.IO.File.ReadAllText(fullPath); //read all the content inside the file

            var elements = JsonConvert.DeserializeObject<List<Element>>(data);

            if (elements == null || elements.Count == 0) return null;

            return elements;
        }

        // GET: api/Elements/5
        [HttpGet("{id}")]
        public IEnumerable<Element> GetElement(int id)
        {

            var rootPath = _hostingEnvironment.ContentRootPath; //get the root path

            var fullPath = Path.Combine(rootPath, "MOCK_DATA.json"); //combine the root path with that of our json file

            var data = System.IO.File.ReadAllText(fullPath); //read all the content inside the file

            var elements = JsonConvert.DeserializeObject<List<Element>>(data);

            if (elements == null || elements.Count == 0) return null;

            var element = elements.Where(o => o.id == id);

            if (element == null || element.Count() == 0 ) return null;

            return element;
        }


    }
}
