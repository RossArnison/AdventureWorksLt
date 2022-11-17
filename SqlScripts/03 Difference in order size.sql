-- order size difference


select
    SalesOrderID,
    OrderQty as OrderQuantity,
    OrderQty - LAG(OrderQty - 1) over (order by SalesOrderId)
from SalesLT.SalesOrderDetail
order by SalesOrderId