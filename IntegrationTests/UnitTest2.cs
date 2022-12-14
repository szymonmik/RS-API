using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic;
using RS_API.Entities;
using RS_API.Models;

namespace IntegrationTests;

public class UnitTest2 : IAsyncLifetime
{
	protected readonly string BaseOrderUrl = "http://localhost:5156/api/order";
	protected readonly string BaseRecordUrl = "http://localhost:5156/api/record";
	private readonly HttpClient _httpClient;

	public UnitTest2()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(BaseOrderUrl);

	}
	[Fact]
	public async Task GivenValidData_ShouldCreateOrder_CreatedOrder()
	{
		// Arrange
		var record1 = new CreateRecordDto()
		{
			Title = "TestTitle",
			Artist = "TestArtist",
			Genre = Genre.Rock,
			Description = "Test desc",
			ReleaseDate = 1980,
			Format = Format.Single,
			Price = 21,
			Stock = 10
		};
		
		var record2= new CreateRecordDto()
		{
			Title = "TestTitle2",
			Artist = "TestArtist2",
			Genre = Genre.Rock,
			Description = "Test desc2",
			ReleaseDate = 1990,
			Format = Format.Maxi,
			Price = 25,
			Stock = 10
		};

		var order = new CreateOrderDto()
		{
			Country = Country.Poland,
			OrderRecords = new List<OrderRecordDto>()
			{
				new OrderRecordDto()
				{
					RecordId = 1,
					Quantity = 2
				},
				new OrderRecordDto()
				{
					RecordId = 2,
					Quantity = 1
				}
			}
		};
		
		// Act
		await _httpClient.PostAsync(BaseRecordUrl, new StringContent(JsonSerializer.Serialize(record1), Encoding.UTF8, "application/json"));
		await _httpClient.PostAsync(BaseRecordUrl, new StringContent(JsonSerializer.Serialize(record2), Encoding.UTF8, "application/json"));
		
		var response = await _httpClient.PostAsync(BaseOrderUrl, new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json"));
		var responseData = await response.Content.ReadFromJsonAsync<int>();
		
		var getResponse = await _httpClient.GetAsync($"{BaseOrderUrl}/{responseData}");
		var getResponseData = await getResponse.Content.ReadFromJsonAsync<OrderDto>();

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