using System.Collections.Generic;

namespace PrototypeData.Models {

    public class DrugSearchResult {
        public string drug_name { get; set; }
        public string DisplayName { get; set; }
        public string dosage_form { get; set; }
        public string strength { get; set; }
        public string strength_unit_of_measure { get; set; }
        public string generic_product_identifier { get; set; }
        public string ndc_upc_hri { get; set; }
        public string multi_source_code { get; set; }
        public string maintenance_drug_code { get; set; }
    }

    public class GPIDto {
        public string GPI { get; set; }
        public string DisplayName { get; set; }
    }
    public class NDCDto {
        public string NDC { get; set; }
        public string DisplayName { get; set; }
        public string MONY { get; set; }
        public string MaintenanceCode { get; set; }
    }

    public class DrugSearchResultDto {
        public string DisplayName { get; set; }
        public List<DrugSearchResult> SearchResults { get; set; } = new List<DrugSearchResult>();
        public List<string> DosageOptions { get; set; } = new List<string>();
        public List<string> Strengths { get; set; } = new List<string>();
        public List<NDCDto> NDCs { get; set; } = new List<NDCDto>();
        public List<GPIDto> GPIs { get; set; } = new List<GPIDto>();
    }
}