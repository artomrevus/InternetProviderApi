using System.Linq.Expressions;
using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Sort;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;
using InternetProvider.Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class InternetConnectionRequestRepository(InternetProviderContext context) : IInternetConnectionRequestRepository
{
    public async Task<IInternetConnectionRequest> GetByIdAsync(int id)
    {
        var internetConnectionRequest = await context.InternetConnectionRequests
            .Include(x => x.Client)
            .Include(x => x.InternetTariff)
            .Include(x => x.InternetConnectionRequestStatus)
            .FirstOrDefaultAsync(x => x.InternetConnectionRequestId == id);
        
        if (internetConnectionRequest is null)
        {
            throw new RepositoryException($"Internet connection request with id {id} was not found");
        }

        return internetConnectionRequest;
    }

    public Task<IEnumerable<IInternetConnectionRequest>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<IInternetConnectionRequest>>(context.InternetConnectionRequests
            .Include(x => x.Client)
            .Include(x => x.InternetTariff)
            .Include(x => x.InternetConnectionRequestStatus));
    }

    public async Task AddAsync(IInternetConnectionRequest entity)
    {
        if (entity is InternetConnectionRequest internetConnectionRequestEntity)
        {
            await context.InternetConnectionRequests.AddAsync(internetConnectionRequestEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type InternetConnectionRequest.");
        }
    }

    public async Task UpdateAsync(int id, IInternetConnectionRequest entity)
    {
        var internetConnectionRequest = await context.InternetConnectionRequests.FindAsync(id);
        if (internetConnectionRequest is null)
        {
            throw new RepositoryException($"Internet connection request with id {id} was not found");
        }
        
        internetConnectionRequest.ClientId = entity.ClientId;
        internetConnectionRequest.InternetTariffId = entity.InternetTariffId;
        internetConnectionRequest.InternetConnectionRequestStatusId = entity.InternetConnectionRequestStatusId;
        internetConnectionRequest.Number = entity.Number;
        internetConnectionRequest.RequestDate = entity.RequestDate;
        internetConnectionRequest.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var internetConnectionRequest = await context.InternetConnectionRequests.FindAsync(id);
        if (internetConnectionRequest is null)
        {
            throw new RepositoryException($"Internet connection request with id {id} was not found");
        }
        
        context.InternetConnectionRequests.Remove(internetConnectionRequest);
    }

    public Task<IEnumerable<IInternetConnectionRequest>> GetAsync(
        Dictionary<string, object>? filter, 
        Dictionary<string, SortType>? sort, 
        int? pageNumber, 
        int? pageSize)
    {
        IQueryable<IInternetConnectionRequest> internetConnectionRequests = context.InternetConnectionRequests
            .Include(x => x.Client)
            .Include(x => x.InternetTariff)
            .Include(x => x.InternetConnectionRequestStatus);

        if (filter is not null)
        {
            internetConnectionRequests = ApplyFilter(internetConnectionRequests, filter);
        }
        
        if (sort is not null)
        {
            internetConnectionRequests = ApplySort(internetConnectionRequests, sort);
        }
        
        if (pageNumber is not null && pageSize is not null)
        {
            internetConnectionRequests = ApplyPagination(internetConnectionRequests, (int)pageNumber, (int)pageSize);
        }
        
        return Task.FromResult(internetConnectionRequests.AsEnumerable());
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        IQueryable<IInternetConnectionRequest> internetConnectionRequests = context.InternetConnectionRequests
            .Include(x => x.Client)
            .Include(x => x.InternetTariff)
            .Include(x => x.InternetConnectionRequestStatus);

        if (filter is not null)
        {
            internetConnectionRequests = ApplyFilter(internetConnectionRequests, filter);
        }
        
        return await internetConnectionRequests.CountAsync();
    }
    
    private IQueryable<IInternetConnectionRequest> ApplyFilter(IQueryable<IInternetConnectionRequest> internetConnectionRequests, Dictionary<string, object> filters)
    {
        foreach (var filter in filters)
        {
            var filterKeyLower = filter.Key.ToLower();

            internetConnectionRequests = filterKeyLower switch
            {
                "clientphonenumber" => internetConnectionRequests.Where(x => x.Client.PhoneNumber.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "clientemail" => internetConnectionRequests.Where(x => x.Client.Email.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "internettariffname" => internetConnectionRequests.Where(x => x.InternetTariff.Name.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "internettariffpricemin" => internetConnectionRequests.Where(x => x.InternetTariff.Price >= filter.Value.ToDecimal()),
                "internettariffpricemax" => internetConnectionRequests.Where(x => x.InternetTariff.Price <= filter.Value.ToDecimal()),
                "internettariffspeedmbitsmin" => internetConnectionRequests.Where(x => x.InternetTariff.InternetSpeedMbits >= filter.Value.ToInt()),
                "internettariffspeedmbitsmax" => internetConnectionRequests.Where(x => x.InternetTariff.InternetSpeedMbits <= filter.Value.ToInt()),
                "internetconnectionrequeststatusname" => internetConnectionRequests.Where(x => x.InternetConnectionRequestStatus.InternetConnectionRequestStatusName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "number" => internetConnectionRequests.Where(x => x.Number.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "requestdatemin" => internetConnectionRequests.Where(x => x.RequestDate >= filter.Value.ToDateOnly()),
                "requestdatemax" => internetConnectionRequests.Where(x => x.RequestDate <= filter.Value.ToDateOnly()),
                "clientid" => internetConnectionRequests.Where(x => x.Client.ClientId == filter.Value.ToInt()),
                _ => throw new RepositoryException($"Filter {filter.Key} is not supported.")
            };
        }
        
        return internetConnectionRequests;
    }
    
    private IQueryable<IInternetConnectionRequest> ApplySort(IQueryable<IInternetConnectionRequest> internetConnectionRequests, Dictionary<string, SortType> sorts)
    {
        IOrderedQueryable<IInternetConnectionRequest>? orderedInternetConnectionRequests = null;

        foreach (var sort in sorts)
        {
            var sortFieldLower = sort.Key.ToLowerInvariant();
            
            Expression<Func<IInternetConnectionRequest, object>> keySelector = sortFieldLower switch
            {
                "clientphonenumber" => x => x.Client.PhoneNumber,
                "clientemail" => x => x.Client.Email,
                "internettariffname" => x => x.InternetTariff.Name,
                "internettariffprice" => x => x.InternetTariff.Price,
                "internettariffspeedmbits" => x => x.InternetTariff.InternetSpeedMbits,
                "internetconnectionrequeststatusname" => x => x.InternetConnectionRequestStatus.InternetConnectionRequestStatusName!,
                "number" => x => x.Number,
                "requestdate" => x => x.RequestDate,
                _ => throw new RepositoryException($"Sort {sort.Key} is not supported.")
            };
            
            orderedInternetConnectionRequests = orderedInternetConnectionRequests is null
                ? internetConnectionRequests.ApplyInitialSort(keySelector, sort.Value)
                : orderedInternetConnectionRequests.ApplyThenBySort(keySelector, sort.Value);
        }

        return orderedInternetConnectionRequests ?? internetConnectionRequests;
    }

    private IQueryable<IInternetConnectionRequest> ApplyPagination(IQueryable<IInternetConnectionRequest> internetConnectionRequests, int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new RepositoryException($"Page number {pageNumber} or page size {pageSize} incorrect.");
        }
        
        return internetConnectionRequests.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}