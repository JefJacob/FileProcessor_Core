﻿using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using System.Configuration;
using System.Data.SqlClient;
using FileProcessor.Entities;

namespace FileProcessor.Repository
{
    public class CompetitionRepo
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static int GetCompetitionId(String fileName)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AODB"].ConnectionString);
            string selectStatement
                = "SELECT * "
                + "FROM Competitions "
                + "WHERE CompName=@CompName";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue(
                "@CompName", fileName.Replace(".mdb", ""));

            try
            {
                connection.Open();
                SqlDataReader proReader =
                    selectCommand.ExecuteReader(
                        System.Data.CommandBehavior.SingleRow);
                if (proReader.Read())
                {
                    int CompId = Convert.ToInt32(proReader["CompId"]);
                    return CompId;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                logger.Error("Exception : " + ex.Message);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string GetCompetitionName(int compId)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AODB"].ConnectionString);
            string selectStatement
                = "SELECT * "
                + "FROM Competitions "
                + "WHERE CompId=@CompId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue(
                "@CompId", compId);

            try
            {
                connection.Open();
                SqlDataReader proReader =
                    selectCommand.ExecuteReader(
                        System.Data.CommandBehavior.SingleRow);
                if (proReader.Read())
                {
                    string CompName = proReader["CompName"].ToString();
                    return CompName;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                logger.Error("Exception : " + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
