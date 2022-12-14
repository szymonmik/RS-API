using AutoMapper;
using RS_API.Entities;
using RS_API.Exceptions;
using RS_API.Models;

namespace RS_API.Services;

public class RecordService : IRecordService
{
	private readonly StoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public RecordService(StoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public int CreateRecord(CreateRecordDto dto)
	{
		var record = _mapper.Map<Record>(dto);

		_dbContext.Add(record);
		_dbContext.SaveChanges();

		return record.Id;
	}

	public RecordDto GetRecord(int recordId)
	{
		var record = _dbContext.Records.FirstOrDefault(x => x.Id == recordId);

		if (record is null)
		{
			throw new NotFoundException("Record not found");
		}

		var recordDto = _mapper.Map<RecordDto>(record);

		return recordDto;
	}

	public IEnumerable<RecordDto> GetAllRecords()
	{
		var records = _dbContext.Records
			.ToList();

		var recordsDto = _mapper.Map<List<RecordDto>>(records);

		return recordsDto;
	}

	public void DeleteRecord(int recordId)
	{
		var record = _dbContext.Records.FirstOrDefault(x => x.Id == recordId);

		if (record is null)
		{
			throw new NotFoundException("Record not found");
		}
	}
}