using Ensek.TechnicalTest.Api.Client.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Ensek.TechnicalTest.UI.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		[Required]
		public IFormFile MeterReadingsFile { get; set; }

		private readonly IEnsekApiClient ensekApiClient;
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(IEnsekApiClient ensekApiClient, ILogger<IndexModel> logger)
		{
			this.ensekApiClient = ensekApiClient;
			_logger = logger;
		}

		public async Task OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				try
				{
					var toFileParameter = new FileParameter(this.MeterReadingsFile.OpenReadStream());
					var result = await this.ensekApiClient.MeterReadingUploadsAsync(toFileParameter);

					_logger.Log(LogLevel.Information, $"TotalUploaded: {result.TotalUploaded}");
					_logger.Log(LogLevel.Information, $"FailedToParse: {result.UploadsFailedToParse}");
					_logger.Log(LogLevel.Information, $"FailedToSave: {result.UploadsFailedToSave}");
					_logger.Log(LogLevel.Information, $"UploadsSuccessfull: {result.UploadsSuccessful}");

					ModelState.AddModelError("UnhandledError", "An error occured performing the requested operation.");
				}
				catch (Exception exception)
				{
					_logger.LogError(exception, "Uknown error occured uploading meter reads.");
					ModelState.AddModelError("UnhandledError", "An error occured performing the requested operation.");
				}
			}
		}

		public void OnGet()
		{

		}
	}
}