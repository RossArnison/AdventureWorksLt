-- top 5 most popular orders

select top 5
    p.ProductID,
    p.Name,
    SUM(sod.OrderQty) as Orders
from SalesLT.Product p
left join SalesLT.SalesOrderDetail sod on p.ProductID = sod.ProductID
group by  p.ProductID, p.Name
order by Orders desc