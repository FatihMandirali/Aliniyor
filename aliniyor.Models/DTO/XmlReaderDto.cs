using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Models.DTO
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AddressInfo
    {

        private AddressInfoCity[] cityField;

        [System.Xml.Serialization.XmlElementAttribute("City")]
        public AddressInfoCity[] City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AddressInfoCity
    {

        private AddressInfoCityDistrict[] districtField;

        private string nameField;

        private string codeField;

        [System.Xml.Serialization.XmlElementAttribute("District")]
        public AddressInfoCityDistrict[] District
        {
            get
            {
                return this.districtField;
            }
            set
            {
                this.districtField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AddressInfoCityDistrict
    {

        private AddressInfoCityDistrictZip[] zipField;

        private string nameField;

        [System.Xml.Serialization.XmlElementAttribute("Zip")]
        public AddressInfoCityDistrictZip[] Zip
        {
            get
            {
                return this.zipField;
            }
            set
            {
                this.zipField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AddressInfoCityDistrictZip
    {

        private string codeField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
    }
}
