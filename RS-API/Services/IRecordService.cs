using RS_API.Models;

namespace RS_API.Services;

public interface IRecordService
{
	int CreateRecord(CreateRecordDto dto);
	RecordDto GetRecord(int recordId);
	IEnumerable<RecordDto> GetAllRecords();
	void DeleteRecord(int recordId);
}