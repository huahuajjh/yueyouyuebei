DROP VIEW v_order
GO

CREATE VIEW v_order
AS
SELECT 

	o.orderPrice + o.attachPrice + o.subPrice AS OrderAmount,
	CONVERT(NVARCHAR(19),o.orderDate,20) AS OrderTime,
	o.ordercode AS OrderNo,
	CASE o.orderState
		WHEN '0' THEN '已取消'
		WHEN '1' THEN '填写信息'
		WHEN '2' THEN '核对订单'
		WHEN '3' THEN '处理中'
		WHEN '4' THEN '待付款'
		WHEN '5' THEN '已付款'
		WHEN '6' THEN '预订成功'
		ELSE 'NA' END AS Status,
	o.Id AS Id,
	l.lineName AS ProductName,
	l.linePic AS Url,
	o.orderState AS StatusNo,
	c.id AS UserId
	
	FROM [order] o
	LEFT JOIN [line] l ON o.lineId = l.id
	LEFT JOIN [club] c ON c.id = o.clubid