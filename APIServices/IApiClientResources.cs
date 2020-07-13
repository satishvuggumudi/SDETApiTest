using APIServices.ResponseModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IApiClientResources
    {

        /// <summary>
        /// Gets the list cars by type identifier asynchronous.
        /// </summary>
        /// <param name="type">The type. Example: "Saloon", "SUV", "Hatchback"</param>
        /// <returns></returns>
        [Get("/cars/{type}")]
        Task<ApiResponse<IEnumerable<Car>>> GetListCarsByTypeIdAsync(string type);
    }
}
