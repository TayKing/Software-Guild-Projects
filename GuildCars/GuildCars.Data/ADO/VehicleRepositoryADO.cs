using GuildCars.Data;
using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildVehicles.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void ResetToSampleData()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DBReset", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public List<BodyStyle> GetAllBodyStyles()
        {
            List<BodyStyle> BodyStyle = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle CurrentRow = new BodyStyle();
                        CurrentRow.BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.Body = dr["Body"].ToString();

                        BodyStyle.Add(CurrentRow);
                    }
                }
            }
            return BodyStyle;
        }
        public BodyStyle GetBodyStyleByID(int SearchID)
        {
            List<BodyStyle> BodyStyleTypes = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle CurrentRow = new BodyStyle();
                        CurrentRow.BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.Body = dr["Body"].ToString();

                        BodyStyleTypes.Add(CurrentRow);
                    }
                }
            }
            if (BodyStyleTypes.Count > 0)
                return BodyStyleTypes[0];
            return null;
        }

        public List<Color> GetAllColors()
        {
            List<Color> Colors = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color CurrentRow = new Color();
                        CurrentRow.ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.VehicleColor = dr["VehicleColor"].ToString();

                        Colors.Add(CurrentRow);
                    }
                }
            }
            return Colors;
        }
        public Color GetColorByID(int SearchID)
        {
            List<Color> Colors = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color CurrentRow = new Color();
                        CurrentRow.ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.VehicleColor = dr["VehicleColor"].ToString();

                        Colors.Add(CurrentRow);
                    }
                }
            }
            if (Colors.Count > 0)
                return Colors[0];
            return null;
        }

        public List<Make> GetAllMakes()
        {
            List<Make> Makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make CurrentRow = new Make();
                        CurrentRow.MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.MakeName = dr["MakeName"].ToString();
                        CurrentRow.UserCreated = dr["UserCreated"].ToString();
                        CurrentRow.DateCreated = dr["DateCreated"].ToString();

                        Makes.Add(CurrentRow);
                    }
                }
            }
            return Makes;
        }
        public Make GetMakeByID(int SearchID)
        {
            List<Make> Makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make CurrentRow = new Make();
                        CurrentRow.MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.MakeName = dr["MakeName"].ToString();
                        CurrentRow.UserCreated = dr["UserCreated"].ToString();
                        CurrentRow.DateCreated = dr["DateCreated"].ToString();

                        Makes.Add(CurrentRow);
                    }
                }
            }
            if (Makes.Count > 0)
                return Makes[0];
            return null;
        }

        public List<Model> GetAllModels()
        {
            List<Model> Models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model CurrentRow = new Model();
                        CurrentRow.MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.ModelName = dr["ModelName"].ToString();
                        CurrentRow.UserCreated = dr["UserCreated"].ToString();
                        CurrentRow.DateCreated = dr["DateCreated"].ToString();

                        Models.Add(CurrentRow);
                    }
                }
            }
            return Models;
        }
        public Model GetModelByID(int SearchID)
        {
            List<Model> Models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model CurrentRow = new Model();
                        CurrentRow.MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.ModelName = dr["ModelName"].ToString();
                        CurrentRow.UserCreated = dr["UserCreated"].ToString();
                        CurrentRow.DateCreated = dr["DateCreated"].ToString();

                        Models.Add(CurrentRow);
                    }
                }
            }
            if (Models.Count > 0)
                return Models[0];
            return null;
        }
        public List<Model> GetModelsByMakeID(int SearchID)
        {
            List<Model> Models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectByMakeID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model CurrentRow = new Model();
                        CurrentRow.MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.ModelName = dr["ModelName"].ToString();
                        CurrentRow.UserCreated = dr["UserCreated"].ToString();
                        CurrentRow.DateCreated = dr["DateCreated"].ToString();

                        Models.Add(CurrentRow);
                    }
                }
            }
            return Models;
        }

        public List<SalesType> GetAllSalesTypes()
        {
            List<SalesType> SalesTypes = new List<SalesType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesTypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesType CurrentRow = new SalesType();
                        CurrentRow.SalesTypeID = int.Parse(dr["SalesTypeID"].ToString());
                        CurrentRow.SalesTypeName = dr["SalesTypeName"].ToString();

                        SalesTypes.Add(CurrentRow);
                    }
                }
            }
            return SalesTypes;
        }
        public SalesType GetSalesTypeByID(int SearchID)
        {
            List<SalesType> SalesTypes = new List<SalesType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesTypeSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesType CurrentRow = new SalesType();
                        CurrentRow.SalesTypeID = int.Parse(dr["SalesTypeID"].ToString());
                        CurrentRow.SalesTypeName = dr["SalesTypeName"].ToString();

                        SalesTypes.Add(CurrentRow);
                    }
                }
            }
            if (SalesTypes.Count > 0)
                return SalesTypes[0];
            return null;
        }

        public List<Special> GetAllSpecials()
        {
            List<Special> Specials = new List<Special>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special CurrentRow = new Special();
                        CurrentRow.SpecialID = int.Parse(dr["SpecialID"].ToString());
                        CurrentRow.SpecialName = dr["SpecialName"].ToString();
                        CurrentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        Specials.Add(CurrentRow);
                    }
                }
            }
            return Specials;
        }
        public Special GetSpecialByID(int SearchID)
        {
            List<Special> Specials = new List<Special>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special CurrentRow = new Special();
                        CurrentRow.SpecialID = int.Parse(dr["SpecialID"].ToString());
                        CurrentRow.SpecialName = dr["SpecialName"].ToString();
                        CurrentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        Specials.Add(CurrentRow);
                    }
                }
            }
            if (Specials.Count > 0)
                return Specials[0];
            return null;
        }

        public List<State> GetAllStates()
        {
            List<State> States = new List<State>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State CurrentRow = new State();
                        CurrentRow.StateID = dr["StateID"].ToString();
                        CurrentRow.StateName = dr["StateName"].ToString();

                        States.Add(CurrentRow);
                    }
                }
            }
            return States;
        }
        public State GetStateByID(string SearchID)
        {
            List<State> States = new List<State>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State CurrentRow = new State();
                        CurrentRow.StateID = dr["StateID"].ToString();
                        CurrentRow.StateName = dr["StateName"].ToString();

                        States.Add(CurrentRow);
                    }
                }
            }
            if (States.Count > 0)
                return States[0];
            return null;
        }

        public List<Transmission> GetAllTransmissionTypes()
        {
            List<Transmission> Transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission CurrentRow = new Transmission();
                        CurrentRow.TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.TransmissionType = dr["TransmissionType"].ToString();

                        Transmissions.Add(CurrentRow);
                    }
                }
            }
            return Transmissions;
        }
        public Transmission GetTransmissionTypeByID(int SearchID)
        {
            List<Transmission> Transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission CurrentRow = new Transmission();
                        CurrentRow.TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.TransmissionType = dr["TransmissionType"].ToString();

                        Transmissions.Add(CurrentRow);
                    }
                }
            }
            if (Transmissions.Count > 0)
                return Transmissions[0];
            return null;
        }

        public List<VehicleViewModel> GetAllVehicles()
        {
            List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel CurrentRow = new VehicleViewModel();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        int BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.BodyStyle = GetBodyStyleByID(BodyStyleID).Body;

                        int TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.Transmission = GetTransmissionTypeByID(TransmissionID).TransmissionType;

                        int ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.Color = GetColorByID(ColorID).VehicleColor;

                        int InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Interior = GetColorByID(InteriorID).VehicleColor;

                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }
            return Vehicles;
        }
        public List<VehicleViewModel> GetNewVehicles()
        {
            List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel CurrentRow = new VehicleViewModel();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        int BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.BodyStyle = GetBodyStyleByID(BodyStyleID).Body;

                        int TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.Transmission = GetTransmissionTypeByID(TransmissionID).TransmissionType;

                        int ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.Color = GetColorByID(ColorID).VehicleColor;

                        int InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Interior = GetColorByID(InteriorID).VehicleColor;

                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }
            return Vehicles;
        }
        public List<VehicleViewModel> GetUsedVehicles()
        {
            List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel CurrentRow = new VehicleViewModel();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        int BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.BodyStyle = GetBodyStyleByID(BodyStyleID).Body;

                        int TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.Transmission = GetTransmissionTypeByID(TransmissionID).TransmissionType;

                        int ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.Color = GetColorByID(ColorID).VehicleColor;

                        int InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Interior = GetColorByID(InteriorID).VehicleColor;

                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }
            return Vehicles;
        }
        public List<VehicleViewModel> GetFeaturedVehicles()
        {
            List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel CurrentRow = new VehicleViewModel();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        int BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.BodyStyle = GetBodyStyleByID(BodyStyleID).Body;

                        int TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.Transmission = GetTransmissionTypeByID(TransmissionID).TransmissionType;

                        int ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.Color = GetColorByID(ColorID).VehicleColor;

                        int InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Interior = GetColorByID(InteriorID).VehicleColor;

                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }
            return Vehicles;
        }

        public VehicleViewModel GetVehicleByID(int SearchID)
        {
            List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel CurrentRow = new VehicleViewModel();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        int BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.BodyStyle = GetBodyStyleByID(BodyStyleID).Body;

                        int TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.Transmission = GetTransmissionTypeByID(TransmissionID).TransmissionType;

                        int ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.Color = GetColorByID(ColorID).VehicleColor;

                        int InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Interior = GetColorByID(InteriorID).VehicleColor;

                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }
            if (Vehicles.Count > 0)
                return Vehicles[0];
            return null;
        }
        public Vehicle GetVehicleDataByID(int SearchID)
        {
            List<Vehicle> Vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchID", SearchID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle CurrentRow = new Vehicle();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());
                        CurrentRow.MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }
            if (Vehicles.Count > 0)
                return Vehicles[0];
            return null;
        }


        public List<VehicleViewModel> SearchVehicles(QuickSearchParameters searchParameters)
        {
            List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT ";

                if (searchParameters.IsNew != null)
                    cmd.CommandText += "TOP 20 ";

                cmd.CommandText += "c.VehicleID, c.[VehicleYear], c.MakeID, c.ModelID, c.BodyStyleID, c.TransmissionID, c.ColorID, c.InteriorID, " +
                                    "c.Mileage, c.VIN, c.Price, c.MSRP, c.IsFeatured, c.IsNew, c.IsSold, c.[VehicleDescription]," +
                                    "ma.MakeName, mo.ModelName " +
                                 "FROM Vehicle c " +
                                 "INNER JOIN Make ma ON c.MakeID = ma.MakeID " +
                                 "INNER JOIN Model mo ON c.ModelID = mo.ModelID " +
                                 "WHERE 1 = 1 ";

                switch (searchParameters.IsNew)
                {
                    case true:
                        cmd.CommandText += "AND IsNew = 1 ";
                        break;
                    case false:
                        cmd.CommandText += "AND IsNew = 0 ";
                        break;
                }

                if (searchParameters.QueryString != null)
                {
                    cmd.Parameters.AddWithValue("queryString", searchParameters.QueryString);
                    cmd.CommandText += "AND( " +
                                       "@queryString LIKE '%' + cast([VehicleYear] AS nvarchar) + '%' OR " +
                                       "@queryString LIKE '%' + MakeName + '%' OR " +
                                       "@queryString LIKE '%' + ModelName + '%'" +
                                       ") ";
                }

                if (searchParameters.MinPrice != null)
                {
                    cmd.Parameters.AddWithValue("minPrice", searchParameters.MinPrice);
                    cmd.CommandText += "AND Price >= @minPrice ";
                }
                if (searchParameters.MaxPrice != null)
                {
                    cmd.Parameters.AddWithValue("maxPrice", searchParameters.MaxPrice);
                    cmd.CommandText += "AND Price <= @maxPrice ";
                }
                if (searchParameters.MinYear != null)
                {
                    cmd.Parameters.AddWithValue("minVehicleYear", searchParameters.MinYear);
                    cmd.CommandText += "AND VehicleYear >= @minVehicleYear ";
                }
                if (searchParameters.MaxYear != null)
                {
                    cmd.Parameters.AddWithValue("maxVehicleYear", searchParameters.MaxYear);
                    cmd.CommandText += "AND VehicleYear <= @maxVehicleYear ";
                }

                cmd.CommandText += "AND IsSold = 0 ";
                cmd.CommandText += "ORDER BY MSRP DESC";

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel CurrentRow = new VehicleViewModel();
                        CurrentRow.VehicleID = int.Parse(dr["VehicleID"].ToString());
                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        int BodyStyleID = int.Parse(dr["BodyStyleID"].ToString());
                        CurrentRow.BodyStyle = GetBodyStyleByID(BodyStyleID).Body;

                        int TransmissionID = int.Parse(dr["TransmissionID"].ToString());
                        CurrentRow.Transmission = GetTransmissionTypeByID(TransmissionID).TransmissionType;

                        int ColorID = int.Parse(dr["ColorID"].ToString());
                        CurrentRow.Color = GetColorByID(ColorID).VehicleColor;

                        int InteriorID = int.Parse(dr["InteriorID"].ToString());
                        CurrentRow.Interior = GetColorByID(InteriorID).VehicleColor;

                        CurrentRow.Mileage = int.Parse(dr["Mileage"].ToString());
                        CurrentRow.VIN = dr["VIN"].ToString();
                        CurrentRow.Price = int.Parse(dr["Price"].ToString());
                        CurrentRow.MSRP = int.Parse(dr["MSRP"].ToString());
                        CurrentRow.IsFeatured = dr.GetBoolean(dr.GetOrdinal("IsFeatured"));
                        CurrentRow.IsNew = dr.GetBoolean(dr.GetOrdinal("IsNew"));
                        CurrentRow.IsSold = dr.GetBoolean(dr.GetOrdinal("IsSold"));
                        CurrentRow.VehicleDescription = dr["VehicleDescription"].ToString();

                        Vehicles.Add(CurrentRow);
                    }
                }
            }

            return Vehicles;
        }

        public void AddSpecial(Special toAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialName", toAdd.SpecialName);
                cmd.Parameters.AddWithValue("@SpecialDescription", toAdd.SpecialDescription);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSpecial(int Id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialID", Id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddMake(Make toAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeName", toAdd.MakeName);
                cmd.Parameters.AddWithValue("@DateCreated", toAdd.DateCreated);
                cmd.Parameters.AddWithValue("@UserCreated", toAdd.UserCreated);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddModel(Model toAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", toAdd.MakeID);
                cmd.Parameters.AddWithValue("@ModelName", toAdd.ModelName);
                cmd.Parameters.AddWithValue("@DateCreated", toAdd.DateCreated);
                cmd.Parameters.AddWithValue("@UserCreated", toAdd.UserCreated);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddContact(Contact toAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactName", toAdd.ContactName);
                if (!string.IsNullOrEmpty(toAdd.ContactPhone))
                    cmd.Parameters.AddWithValue("@ContactPhone", toAdd.ContactPhone);
                else
                    cmd.Parameters.AddWithValue("@ContactPhone", DBNull.Value);
                if (!string.IsNullOrEmpty(toAdd.ContactEmail))
                    cmd.Parameters.AddWithValue("@ContactEmail", toAdd.ContactEmail);
                else
                    cmd.Parameters.AddWithValue("@ContactEmail", DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactReason", toAdd.ContactReason);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int AddVehicle(Vehicle toAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleYear", toAdd.VehicleYear);
                cmd.Parameters.AddWithValue("@MakeID", toAdd.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", toAdd.ModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", toAdd.BodyStyleID);
                cmd.Parameters.AddWithValue("@TransmissionID", toAdd.TransmissionID);
                cmd.Parameters.AddWithValue("@ColorID", toAdd.ColorID);
                cmd.Parameters.AddWithValue("@InteriorID", toAdd.InteriorID);
                cmd.Parameters.AddWithValue("@Mileage", toAdd.Mileage);
                cmd.Parameters.AddWithValue("@VIN", toAdd.VIN);
                cmd.Parameters.AddWithValue("@Price", toAdd.Price);
                cmd.Parameters.AddWithValue("@MSRP", toAdd.MSRP);
                cmd.Parameters.AddWithValue("@VehicleDescription", toAdd.VehicleDescription);
                cmd.Parameters.AddWithValue("@IsSold", 0);

                if (toAdd.IsFeatured) { cmd.Parameters.AddWithValue("@IsFeatured", 1); }
                else { cmd.Parameters.AddWithValue("@IsFeatured", 0); }

                if (toAdd.IsNew) { cmd.Parameters.AddWithValue("@IsNew", 1); }
                else { cmd.Parameters.AddWithValue("@IsNew", 0); }

                SqlParameter p = new SqlParameter();
                p.ParameterName = "@VehicleID";
                p.DbType = DbType.Int32;
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);

                cn.Open();
                cmd.ExecuteNonQuery();

                int AddedID = int.Parse(cmd.Parameters["@VehicleID"].Value.ToString());
                return AddedID;
            }
        }
        public int UpdateVehicle(Vehicle toUpdate)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleID", toUpdate.VehicleID);
                cmd.Parameters.AddWithValue("@VehicleYear", toUpdate.VehicleYear);
                cmd.Parameters.AddWithValue("@MakeID", toUpdate.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", toUpdate.ModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", toUpdate.BodyStyleID);
                cmd.Parameters.AddWithValue("@TransmissionID", toUpdate.TransmissionID);
                cmd.Parameters.AddWithValue("@ColorID", toUpdate.ColorID);
                cmd.Parameters.AddWithValue("@InteriorID", toUpdate.InteriorID);
                cmd.Parameters.AddWithValue("@Mileage", toUpdate.Mileage);
                cmd.Parameters.AddWithValue("@VIN", toUpdate.VIN);
                cmd.Parameters.AddWithValue("@Price", toUpdate.Price);
                cmd.Parameters.AddWithValue("@MSRP", toUpdate.MSRP);
                cmd.Parameters.AddWithValue("@VehicleDescription", toUpdate.VehicleDescription);
                cmd.Parameters.AddWithValue("@IsSold", 0);

                if (toUpdate.IsFeatured) { cmd.Parameters.AddWithValue("@IsFeatured", 1); }
                else { cmd.Parameters.AddWithValue("@IsFeatured", 0); }

                if (toUpdate.IsNew) { cmd.Parameters.AddWithValue("@IsNew", 1); }
                else { cmd.Parameters.AddWithValue("@IsNew", 0); }

                cn.Open();
                cmd.ExecuteNonQuery();

                return toUpdate.VehicleID;
            }
        }

        public void DeleteVehicle(int Id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleID", Id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddSale(Sales toAdd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleID", toAdd.VehicleID);
                cmd.Parameters.AddWithValue("@UserID", toAdd.UserID);
                cmd.Parameters.AddWithValue("@CustomerName", toAdd.CustomerName);

                if (string.IsNullOrEmpty(toAdd.CustomerPhone))
                    cmd.Parameters.AddWithValue("@CustomerPhone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CustomerPhone", toAdd.CustomerPhone);

                if (string.IsNullOrEmpty(toAdd.CustomerEmail))
                    cmd.Parameters.AddWithValue("@CustomerEmail", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CustomerEmail", toAdd.CustomerEmail);

                cmd.Parameters.AddWithValue("@CustomerAdd1", toAdd.CustomerAdd1);

                if (string.IsNullOrEmpty(toAdd.CustomerAdd2))
                    cmd.Parameters.AddWithValue("@CustomerAdd2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CustomerAdd2", toAdd.CustomerAdd2);

                cmd.Parameters.AddWithValue("@City", toAdd.City);
                cmd.Parameters.AddWithValue("@StateID", toAdd.StateID);
                cmd.Parameters.AddWithValue("@Zipcode", toAdd.Zipcode);
                cmd.Parameters.AddWithValue("@SalesPrice", toAdd.SalesPrice);
                cmd.Parameters.AddWithValue("@SalesTypeID", toAdd.SalesTypeID);
                cmd.Parameters.AddWithValue("@SalesDate", toAdd.SalesDate);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public List<InventoryReport> GetInventoryReport(bool SearchNew)
        {

            List<InventoryReport> Reports = new List<InventoryReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd;
                if (SearchNew)
                    cmd = new SqlCommand("InvReportNew", cn);
                else
                    cmd = new SqlCommand("InvReportUsed", cn);

                cmd.CommandType = CommandType.StoredProcedure;


                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        InventoryReport CurrentRow = new InventoryReport();

                        CurrentRow.VehicleYear = int.Parse(dr["VehicleYear"].ToString());

                        int MakeID = int.Parse(dr["MakeID"].ToString());
                        CurrentRow.Make = GetMakeByID(MakeID).MakeName;

                        int ModelID = int.Parse(dr["ModelID"].ToString());
                        CurrentRow.Model = GetModelByID(ModelID).ModelName;

                        CurrentRow.Count = int.Parse(dr["Count"].ToString());

                        CurrentRow.StockValue = int.Parse(dr["Value"].ToString());

                        Reports.Add(CurrentRow);
                    }
                }
            }

            return Reports;
        }

        public List<SalesReport> GetSalesReport(string UserID, string StartDate, string EndDate)
        {
            List<SalesReport> Reports = new List<SalesReport>();
            var AccountRepo = AccountRepositoryFactory.GetRepository();

            bool FilterStart = DateTime.TryParse(StartDate, out DateTime start);
            bool FilterEnd = DateTime.TryParse(EndDate, out DateTime end);

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT COUNT(*) AS VehiclesSold, " +
                                  "SUM(SalesPrice) AS ValueSold, " +
                                  "UserID " +
                                  "FROM Sales " +
                                  "WHERE 1=1 ";

                if (!string.IsNullOrEmpty(UserID))
                    cmd.CommandText += "AND UserID = '" + UserID + "' ";

                if (FilterStart)
                    cmd.CommandText += "AND CAST(SalesDate AS DATETIME2) >= CAST('" + start.ToString("MM'-'dd'-'yyyy") + "' AS DATETIME2) ";
                if (FilterEnd)
                    cmd.CommandText += "AND CAST(SalesDate AS DATETIME2) <= CAST('" + end.ToString("MM'-'dd'-'yyyy") + "' AS DATETIME2) ";


                cmd.CommandText += " GROUP BY UserID";

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport CurrentRow = new SalesReport();
                        string Id = dr["UserID"].ToString();
                        User Seller = AccountRepo.GetUserByID(Id);
                        CurrentRow.Name = Seller.FirstName + " " + Seller.LastName;

                        CurrentRow.TotalSales = int.Parse(dr["ValueSold"].ToString());
                        CurrentRow.TotalVehicles = int.Parse(dr["VehiclesSold"].ToString());

                        Reports.Add(CurrentRow);
                    }
                }
            }
            return Reports;
        }

    }
}
