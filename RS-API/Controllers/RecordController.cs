using Microsoft.AspNetCore.Mvc;
using RS_API.Models;
using RS_API.Services;

namespace RS_API.Controllers;

[Route("api/record")]
[ApiController]
public class RecordController : ControllerBase
{
	private readonly IRecordService _recordService;

	public RecordController(IRecordService recordService)
	{
		_recordService = recordService;
	}

	[HttpGet]
	public ActionResult<IEnumerable<RecordDto>> GetAll()
	{
		var result = _recordService.GetAllRecords();

		return Ok(result);
	}
	
	[HttpGet("{recordId}")]
	public ActionResult<IEnumerable<RecordDto>> GetAll([FromRoute] int recordId)
	{
		var result = _recordService.GetRecord(recordId);

		return Ok(result);
	}

	[HttpPost]
	public ActionResult Create(CreateRecordDto dto)
	{
		var recordId = _recordService.CreateRecord(dto);
		
		return Ok(recordId);
	}

	[HttpDelete("{recordId}")]
	public ActionResult Delete([FromRoute] int recordId)
	{
		_recordService.DeleteRecord(recordId);

		return NoContent();
	}
}