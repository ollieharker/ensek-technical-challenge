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
		public const string UploadErrorViewDataKey = "UploadErrorMessage";

		[BindProperty]
		[Required]
		public IFormFile MeterReadingsFile { get; set; }

		[BindProperty]
		public MeterReadingUploadResult? MeterReadingUploadResult { get; set; }

		[BindProperty]
		public string? MeterReadingUploadResultFailure { get; set; }


		private readonly IEnsekApiClient ensekApiClient;
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(IEnsekApiClient ensekApiClient, ILogger<IndexModel> logger)
		{
			this.ensekApiClient = ensekApiClient;
			_logger = logger;
		}

		public async Task OnPostAsync()
		{
			this.MeterReadingUploadResult = default;
			if (ModelState.IsValid)
			{
				try
				{
					var toFileParameter = new FileParameter(this.MeterReadingsFile.OpenReadStream());
					var apiResult = await this.ensekApiClient.MeterReadingUploadsAsync(toFileParameter);
					
					if (apiResult.Success)
					{
						this.MeterReadingUploadResult = apiResult.Result;
					}
					else
					{
						this.MeterReadingUploadResultFailure = apiResult.Error;
					}

				}
				catch (Exception exception)
				{
					_logger.LogError(exception, "Unknown error occured uploading meter reads.");
					this.MeterReadingUploadResultFailure = "Unknown error occured uploading meter reads.";
				}
			}
		}

		public void OnGet()
		{

		}
	}
}