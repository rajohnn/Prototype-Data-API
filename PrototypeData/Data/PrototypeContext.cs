using Microsoft.EntityFrameworkCore;
using PrototypeData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrototypeData.Data {

    public class PrototypeContext : DbContext {

        public PrototypeContext(DbContextOptions<PrototypeContext> options) : base(options) {
        }
    }

    public class PrototypeRepo {
        protected PrototypeContext _ctx;

        public PrototypeRepo(PrototypeContext ctx) {
            _ctx = ctx;
        }

        public async Task<List<string>> GetDrugNamesAsync() {
            var names = new List<string>();
            var conn = _ctx.Database.GetDbConnection();
            try {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = "select distinct drug_name from mf2name_f";
                    cmd.CommandType = CommandType.Text;
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        while (rdr.Read()) {
                            names.Add(rdr.GetString(0));
                        }
                    }
                }
            }
            catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            
            return names;
        }

        public async Task<List<DrugSearchResult>> FindByGPIAsync(string gpi) {
            var results = new List<DrugSearchResult>();
            var conn = _ctx.Database.GetDbConnection();
            try {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    var parm1 = new SqlParameter("@GPI", gpi);

                    cmd.CommandText = "FindByGPI";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(parm1);
                    
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        while (rdr.Read()) {
                            var result = new DrugSearchResult();
                            result.dosage_form = rdr["dosage_form"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("dosage_form")) : "";
                            result.drug_name = rdr["drug_name"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("drug_name")) : "";
                            result.generic_product_identifier = rdr["generic_product_identifier"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("generic_product_identifier")) : "";
                            result.maintenance_drug_code = rdr["maintenance_drug_code"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("maintenance_drug_code")) : "";
                            result.multi_source_code = rdr["multi_source_code"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("multi_source_code")) : "";
                            result.ndc_upc_hri = rdr["ndc_upc_hri"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("ndc_upc_hri")) : "";
                            result.strength = rdr["strength"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("strength")) : "";
                            result.strength_unit_of_measure = rdr["strength_unit_of_measure"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("strength_unit_of_measure")) : "";
                            result.DisplayName = rdr["DisplayName"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("DisplayName")) : "";
                            results.Add(result);
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }
        public async Task<List<DrugSearchResult>> FindByNDCAsync(string ndc) {
            var results = new List<DrugSearchResult>();
            var conn = _ctx.Database.GetDbConnection();
            try {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    var parm1 = new SqlParameter("@NDC", ndc);

                    cmd.CommandText = "FindByNDC";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(parm1);

                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        while (rdr.Read()) {
                            var result = new DrugSearchResult();
                            result.dosage_form = rdr["dosage_form"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("dosage_form")) : "";
                            result.drug_name = rdr["drug_name"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("drug_name")) : "";
                            result.generic_product_identifier = rdr["generic_product_identifier"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("generic_product_identifier")) : "";
                            result.maintenance_drug_code = rdr["maintenance_drug_code"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("maintenance_drug_code")) : "";
                            result.multi_source_code = rdr["multi_source_code"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("multi_source_code")) : "";
                            result.ndc_upc_hri = rdr["ndc_upc_hri"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("ndc_upc_hri")) : "";
                            result.strength = rdr["strength"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("strength")) : "";
                            result.strength_unit_of_measure = rdr["strength_unit_of_measure"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("strength_unit_of_measure")) : "";
                            result.DisplayName = rdr["DisplayName"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("DisplayName")) : "";
                            results.Add(result);
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }
        public async Task<List<DrugSearchResult>> FindByNameAsync(string name) {
            var results = new List<DrugSearchResult>();
            var conn = _ctx.Database.GetDbConnection();
            try {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    var parm1 = new SqlParameter("@DrugName", name);

                    cmd.CommandText = "FindByName";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(parm1);

                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        while (rdr.Read()) {
                            var result = new DrugSearchResult();
                            result.dosage_form = rdr["dosage_form"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("dosage_form")) : "";
                            result.drug_name = rdr["drug_name"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("drug_name")) : "";
                            result.generic_product_identifier = rdr["generic_product_identifier"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("generic_product_identifier")) : "";
                            result.maintenance_drug_code = rdr["maintenance_drug_code"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("maintenance_drug_code")) : "";
                            result.multi_source_code = rdr["multi_source_code"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("multi_source_code")) : "";
                            result.ndc_upc_hri = rdr["ndc_upc_hri"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("ndc_upc_hri")) : "";
                            result.strength = rdr["strength"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("strength")) : "";
                            result.strength_unit_of_measure = rdr["strength_unit_of_measure"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("strength_unit_of_measure")) : "";
                            result.DisplayName = rdr["DisplayName"] != DBNull.Value ? rdr.GetString(rdr.GetOrdinal("DisplayName")) : "";
                            results.Add(result);
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }

        public async Task<List<GPIDto>> GetPartialGPINamesAsync(List<string> partialGPIs) {
            var list = new List<GPIDto>();
            var conn = _ctx.Database.GetDbConnection();

            try {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("GPI", typeof(string)));
                partialGPIs.ForEach(gpi => {
                    dataTable.Rows.Add(gpi);
                });

                var parm = new SqlParameter("@List", SqlDbType.Structured) {
                    TypeName = "dbo.GPIList",
                    Value = dataTable
                };

                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandText = "GetGPIDisplayNames";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parm);
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        while (rdr.Read()) {
                            var item = new GPIDto {
                                GPI = rdr.GetString(0),
                                DisplayName = rdr.GetString(1)
                            };
                            list.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return list;
        }
    }
}