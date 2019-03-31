using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Freund
    {

        #region Datenbankschicht
        [Key]
        public Int64 FreundID { get; set; }
        [Required]
        public String Vorname { get; set; }
        [Required]
        public String Nachname { get; set; }
        [Required]
        public String Adresse { get; set; }
        [Required]
        public Int64 PLZ { get; set; }
        [Required]
        public String Ort { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public String Handynummer { get; set; }
        public String Email { get; set; }
        public Boolean Beziehungsstatus { get; set; }
        public String Beziehung { get; set; }
        public DateTime BefreundetSeit { get; set; }

        #endregion
        #region Applikationsschicht
        public Freund() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static IEnumerable<Data.Freund> LesenAlle()
        {
            return (from record in Data.Global.context.Freund select record);
        }
        public static Data.Freund LesenID(Int64 klasseAId)
        {
            return (from record in Data.Global.context.Freund where record.FreundID == klasseAId select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Freund> LesenAttributGleich(String suchbegriff)
        {
            return (from record in Data.Global.context.Freund where record.Ort == suchbegriff select record);
        }
        public static IEnumerable<Data.Freund> LesenAttributWie(String suchbegriff)
        {
            return (from record in Data.Global.context.Freund where record.Ort.Contains(suchbegriff) select record);
        }
        public Int64 Erstellen()
        {
            if (this.Ort == null || this.Ort == "") this.Ort = "leer";
            if (this.Geburtsdatum == null) this.Geburtsdatum = DateTime.MinValue;
            Data.Global.context.Freund.Add(this);
            Data.Global.context.SaveChanges();
            return this.FreundID;
        }
        public Int64 Aktualisieren()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.FreundID;
        }
        public void Loeschen()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return FreundID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
