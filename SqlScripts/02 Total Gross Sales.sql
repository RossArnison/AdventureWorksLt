-- total gross salary per region each calandar year

select
    YEAR(soh.OrderDate) as Year,
    SUM(soh.TotalDue) as GrossSales,
    a.CountryRegion
from SalesLT.SalesOrderHeader soh
join SalesLT.Address a on a.AddressID = BillToAddressID
group by soh.OrderDate, a.CountryRegion