using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using RS_API.Entities;
using RS_API.Models;

namespace IntegrationTests;

public class UnitTest1 : IAsyncLifetime
{
	protected readonly string BaseUrl = "http://localhost:5156/api/record";
	private readonly HttpClient _httpClient;

	public UnitTest1()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(BaseUrl);

	}
	[Fact]
	public async Task GivenValidData_ShouldCreateRecord_CreatedRecord()
	{
		// Arrange
		var record = new CreateRecordDto()
		{
			Title = "Dark Side Of The Moon",
			Artist = "Pink Floyd",
			Genre = Genre.ProgressiveRock,
			Description = "Test desc",
			ReleaseDate = 1970,
			Format = Format.Lp,
			Price = 19.90,
			Stock = 10
		};
		
		// Act
		var response = await _httpClient.PostAsync(BaseUrl, new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json"));
		var responseData = await response.Content.ReadFromJsonAsync<int>();
		
		var getResponse = await _httpClient.GetAsync($"{BaseUrl}/{responseData}");
		var getResponseData = await getResponse.Content.ReadFromJsonAsync<RecordDto>();

		// Assert
		response.EnsureSuccessStatusCode();
		Assert.NotNull(getResponseData);
		Assert.Equal(responseData, getResponseData.Id);
	}
	
	public Task InitializeAsync()
	{
		return Task.CompletedTask;
	}

	public Task DisposeAsync()
	{
		_httpClient.Dispose();
		return Task.CompletedTask;
	}
}