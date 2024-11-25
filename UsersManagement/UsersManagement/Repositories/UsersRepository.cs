using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace UsersManagement.Repositories;

public class UsersRepository
{
	private SqlConnection connection;
	
	public UsersRepository()
	{
		connection = new SqlConnection(Constants.ConnectionString);
	}

	public bool CreateUser(string username, string password)
	{
		try
		{
			connection.Open();
			var command = CreateCommand("INSERT INTO Users VALUES(@p1, @p2, @p3)", new Dictionary<string, object>()
			{
				["p1"] = username,
				["p2"] = password,
				["p3"] = DateTime.Now,
			});
			command.ExecuteNonQuery();
			connection.Close();
			return true;
		}
		catch (Exception ex) {return false; }
	}

	public bool ExistsUser(string username)
	{
		connection.Open();
		var command = CreateCommand("SELECT COUNT (*) FROM Users where Username = @p1", new Dictionary<string, object>
		{
			["p1"] = username
		});
		var result = command.ExecuteNonQuery();
		connection.Close();
		return result > 1;
	}

	public bool ValidateUser(string username, string password)
	{
		try
		{
			connection.Open();
			var command = CreateCommand("SELECT COUNT(*) FROM Users WHERE Username = @p1 and Password = @p2", new Dictionary<string, object>
			{
				["p1"] = username,
				["p2"] = password
			});
			var result = (int)command.ExecuteScalar();
			connection.Close();
			return result > 0;
		}
		catch (Exception ex) {return false; }
	}

	public int Count
	{
		get
		{
			connection.Open();
			// کوئری که تعداد یوزرهارو برمیکردونه
			var command = new SqlCommand("SELECT COUNT (*) FROM Users");
			var result = (int)command.ExecuteScalar();
			connection.Close();
			return result;
		}
	}

	private SqlCommand CreateCommand(string commandText, Dictionary<string, object> parameters)
	{
		var command = new SqlCommand(commandText, connection);
		foreach (var parameter in parameters)
		{
			command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
		}
		return command;
	}
}
