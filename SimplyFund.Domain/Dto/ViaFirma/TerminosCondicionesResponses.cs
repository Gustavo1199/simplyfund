using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.ViaFirma
{
    public class App
    {
        public string? typeApp { get; set; }
        public string? urlApp { get; set; }
    }

    public class Customization
    {
        public string? requestMailSubject { get; set; }
        public string? requestMailBody { get; set; }
        public string? callbackMailSuccessSubject { get; set; }
        public string? callbackMailSuccessBody { get; set; }
    }

    public class Document
    {
        public string? templateCode { get; set; }
        public int? templateVersion { get; set; }
        public string? draftedCode { get; set; }
        public string? draftedReference { get; set; }
        public string? templateType { get; set; }
        public List<Item>? items { get; set; }
        public int? numPages { get; set; }
        public bool? autoFinalize { get; set; }
        public bool? deleteSignedDocuments { get; set; }
        public string? watermarkText { get; set; }
        public int? custodyDays { get; set; }
    }

    public class Evidence
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public bool? enabled { get; set; }
        public bool? visible { get; set; }
        public string? code { get; set; }
        public string? status { get; set; }
        public string? helpText { get; set; }
        public List<Position>? positions { get; set; }
        public List<MetadataList>? metadataList { get; set; }
        public string? typeFormatSign { get; set; }
        public Ocr? ocr { get; set; }
        public string? recipientKey { get; set; }
        public string? imageTextLocation { get; set; }
        public int? imageTextSize { get; set; }
    }

    public class History
    {
        public long? start { get; set; }
        public long? ends { get; set; }
        public string? taskName { get; set; }
    }

    public class Item
    {
        public string? key { get; set; }
        public string? value { get; set; }
    }

    public class MetadataList
    {
        public string? key { get; set; }
        public string? value { get; set; }
        public bool? @internal { get; set; }
    }

    public class Notification
    {
        public string? code { get; set; }
        public string? text { get; set; }
        public string? detail { get; set; }
        public SharedLink? sharedLink { get; set; }
        public Customization? customization { get; set; }
    }

    public class Ocr
    {
        public string? key { get; set; }
    }

    public class Policy
    {
        public string? code { get; set; }
        public List<Evidence>? evidences { get; set; }
        public List<Signature>? signatures { get; set; }
    }

    public class Position
    {
        public Rectangle? rectangle { get; set; }
        public int? page { get; set; }
    }

    public class Rectangle
    {
        public int? x { get; set; }
        public int? y { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }

    public class TerminosCondicionesResponses
    {
        public string? code { get; set; }
        public string? externalCode { get; set; }
        public string? groupCode { get; set; }
        public string? appCode { get; set; }
        public Workflow? workflow { get; set; }
        public Notification? notification { get; set; }
        public Document? document { get; set; }
        public List<MetadataList>? metadataList { get; set; }
        public List<Policy>? policies { get; set; }
        public string? callbackURLType { get; set; }
        public string? server { get; set; }
        public string? timeZoneId { get; set; }
        public string? signPageServer { get; set; }
        public string? auditTrailPage { get; set; }
    }

    public class SharedLink
    {
        public string? scheme { get; set; }
        public string? token { get; set; }
        public string? link { get; set; }
        public string? appCode { get; set; }
        public string? subject { get; set; }
        public List<App>? apps { get; set; }
    }

    public class Signature
    {
        public string? type { get; set; }
        public string? code { get; set; }
        public string? status { get; set; }
        public string? typeFormatSign { get; set; }
        public List<Stamper>? stampers { get; set; }
        public int? lastUpdated { get; set; }
    }

    public class Stamper
    {
        public string? type { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? xAxis { get; set; }
        public int? yAxis { get; set; }
        public int? page { get; set; }
    }

    public class Workflow
    {
        public string? current { get; set; }
        public List<History>? history { get; set; }
        public long? initiate { get; set; }
        public long? lastUpdated { get; set; }
        public long? expires { get; set; }
        public string? type { get; set; }
    }
}
