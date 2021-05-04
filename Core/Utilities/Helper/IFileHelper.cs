using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper
{
    public interface IFileHelper
    {
        public string Add(IFormFile file);
        public string Update(string sourcePath, IFormFile file);
        public IResult Delete(string path);
    }
}
