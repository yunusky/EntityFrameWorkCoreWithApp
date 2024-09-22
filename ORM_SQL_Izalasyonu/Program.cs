using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ORM_SQL_Izalasyonu.Models;

namespace ORM_SQL_Izalasyonu
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region ORM'siz Yaklaşım (SQL + Kod)

			//SqlConnection connection = new SqlConnection($"Server=.;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;");

			// connection.Open();

			//SqlCommand command = new(@"
			//select employee.FirstName, Product.ProductName, COUNT(*) [Count] FROM Employees employee
			//INNER JOIN Orders orders
			//	ON employee.EmployeeID = orders.EmployeeID
			//INNER JOIN [Order Details] orderDetail
			//	ON orders.OrderID = orderDetail.OrderID
			//INNER JOIN Products product
			//	ON orderDetail.ProductID = product.ProductID
			//GROUP By employee.FirstName, product.ProductName
			//ORDER By Count(*) DESC
			//", connection);
			//SqlDataReader dr = command.ExecuteReader();
			//while (dr.Read())
			//{
			//	Console.WriteLine($"{dr["FirstName"]} {dr["ProductName"]} {dr["Count"]}");
			//}

			// connection.Close();


			#endregion


			#region ORM'li Yaklaşım (SQL - Kod) 
			
			NorthwindContext context = new();

			#region Kod 1 

			//var query = context.Employees
			//	.Include(employee => employee.Orders)
			//		.ThenInclude(order => order.OrderDetails)
			//		.ThenInclude(orderDetail => orderDetail.Product)
			//	.SelectMany(employee => employee.Orders, (employee, order) => new { employee.FirstName, order.OrderDetails })
			//	.SelectMany(data => data.OrderDetails, (data, orderDetail) => new { data.FirstName, orderDetail.Product.ProductName })
			//	.GroupBy(data => new
			//	{
			//		data.ProductName,
			//		data.FirstName
			//	}).Select(data => new
			//	{
			//		data.Key.FirstName,
			//		data.Key.ProductName,
			//		Count = data.Count()
			//	});

			//var data = query.ToList();
			#endregion

			#region Kod 2 
			var query = from employee in context.Employees
						join order in context.Orders
							on employee.EmployeeId equals order.EmployeeId
						join orderDetail in context.OrderDetails
							on order.OrderId equals orderDetail.OrderId
						join product in context.Products
							on orderDetail.ProductId equals product.ProductId
						select new {employee.FirstName, product.ProductName} into data
						group data by new {data.FirstName, data.ProductName} into result
						select new
						{
							result.Key.FirstName,
							result.Key.ProductName,
							Count = result.Count(),
						};
			var datas = query.ToList();
			#endregion

			#endregion
			Console.WriteLine("Hello, World!");
		}
	}
}
