﻿using System;
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
			var command = new SqlCommand("INSERT INTO Users VALUES(@p1, @p2, @p3)", connection);
			command.Parameters.Add(new SqlParameter("p1", username));
			command.Parameters.Add(new SqlParameter("p2", password));
			command.Parameters.Add(new SqlParameter("p3", DateTime.Now));
			command.ExecuteNonQuery();
			connection.Close();
			return true;
		}
		catch (Exception ex) {return false; }
	}

	public bool ValidateUser(string username, string password)
	{
		try
		{
			connection.Open();
			var command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @p1 and Password = @p2");
			command.Parameters.Add(new SqlParameter("p1", username));
			command.Parameters.Add(new SqlParameter("p1", password));
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
			var command = new SqlCommand("SELECT COUNT (*) FROM Users", connection);
			var result = (int)command.ExecuteScalar();
			connection.Close();
			return result;
		}
	}
}
