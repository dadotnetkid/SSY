using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class WarehouseCapacityPerMaterialTypeModel
    {
        [JsonPropertyName("result")]
        public WarehouseOverviewModel Result { get; set; }
    }

    public class WarehouseOverviewModel
    {

        #region Warehouse Capacity (in yards)

        [JsonPropertyName("ssyCebuWarehouseCapacity")]
        public double SsyCebuWarehouseCapacity { get; set; }
        [JsonPropertyName("ytiCebuWarehouseCapacity")]
        public double YtiCebuWarehouseCapacity { get; set; }
        [JsonPropertyName("cambodiaWarehouseCapacity")]
        public double CambodiaWarehouseCapacity { get; set; }
        [JsonPropertyName("gjmWarehouseCapacity")]
        public double GjmWarehouseCapacity { get; set; }
        [JsonPropertyName("skechersWarehouseCapacity")]
        public double SkechersWarehouseCapacity { get; set; }
        [JsonPropertyName("tmsWarehouseCapacity")]
        public double TmsWarehouseCapacity { get; set; }
        [JsonPropertyName("othersWarehouseCapacity")]
        public double OthersWarehouseCapacity { get; set; }

        #endregion

        #region Current Total Inventory (in yards)

        [JsonPropertyName("ssyCebuCurrentTotalInventory")]
        public double SsyCebuCurrentTotalInventory { get; set; }
        [JsonPropertyName("ytiCebuCurrentTotalInventory")]
        public double YtiCebuCurrentTotalInventory { get; set; }
        [JsonPropertyName("cambodiaCurrentTotalInventory")]
        public double CambodiaCurrentTotalInventory { get; set; }
        [JsonPropertyName("gjmCurrentTotalInventory")]
        public double GjmCurrentTotalInventory { get; set; }
        [JsonPropertyName("skechersCurrentTotalInventory")]
        public double SkechersCurrentTotalInventory { get; set; }
        [JsonPropertyName("tmsCurrentTotalInventory")]
        public double TmsCurrentTotalInventory { get; set; }
        [JsonPropertyName("othersCurrentTotalInventory")]
        public double OthersCurrentTotalInventory { get; set; }

        #endregion

        /// <summary>
        /// Dependent to Reservation waiting for Integration
        /// </summary>
        #region Reserved Fabrics Inventory

        [JsonPropertyName("ssyCebuReservedFabricsInventory")]
        public double SsyCebuReservedFabricsInventory { get; set; }
        [JsonPropertyName("ytiCebuReservedFabricsInventory")]
        public double YtiCebuReservedFabricsInventory { get; set; }
        [JsonPropertyName("cambodiaReservedFabricsInventory")]
        public double CambodiaReservedFabricsInventory { get; set; }
        [JsonPropertyName("gjmReservedFabricsInventory")]
        public double GjmReservedFabricsInventory { get; set; }
        [JsonPropertyName("skechersReservedFabricsInventory")]
        public double SkechersReservedFabricsInventory { get; set; }
        [JsonPropertyName("tmsReservedFabricsInventory")]
        public double TmsReservedFabricsInventory { get; set; }
        [JsonPropertyName("othersReservedFabricsInventory")]
        public double OthersReservedFabricsInventory { get; set; }

        #endregion

        #region Unreserved Fabrics Inventory

        [JsonPropertyName("ssyCebuUnreservedFabricsInventory")]
        public double SsyCebuUnreservedFabricsInventory { get; set; }
        [JsonPropertyName("ytiCebuUnreservedFabricsInventory")]
        public double YtiCebuUnreservedFabricsInventory { get; set; }
        [JsonPropertyName("cambodiaUnreservedFabricsInventory")]
        public double CambodiaUnreservedFabricsInventory { get; set; }
        [JsonPropertyName("gjmUnreservedFabricsInventory")]
        public double GjmUnreservedFabricsInventory { get; set; }
        [JsonPropertyName("skechersUnreservedFabricsInventory")]
        public double SkechersUnreservedFabricsInventory { get; set; }
        [JsonPropertyName("tmsUnreservedFabricsInventory")]
        public double TmsUnreservedFabricsInventory { get; set; }
        [JsonPropertyName("othersUnreservedFabricsInventory")]
        public double OthersUnreservedFabricsInventory { get; set; }

        #endregion

        #region Incoming Fabric Deliveries (in yards)

        [JsonPropertyName("ssyCebuIncomingFabricsDeliveries")]
        public double SsyCebuIncomingFabricsDeliveries { get; set; }
        [JsonPropertyName("ytiCebuIncomingFabricsDeliveries")]
        public double YtiCebuIncomingFabricsDeliveries { get; set; }
        [JsonPropertyName("cambodiaIncomingFabricsDeliveries")]
        public double CambodiaIncomingFabricsDeliveries { get; set; }
        [JsonPropertyName("gjmIncomingFabricsDeliveries")]
        public double GjmIncomingFabricsDeliveries { get; set; }
        [JsonPropertyName("skechersIncomingFabricsDeliveries")]
        public double SkechersIncomingFabricsDeliveries { get; set; }
        [JsonPropertyName("tmsIncomingFabricsDeliveries")]
        public double TmsIncomingFabricsDeliveries { get; set; }
        [JsonPropertyName("othersIncomingFabricsDeliveries")]
        public double OthersIncomingFabricsDeliveries { get; set; }

        #endregion

        #region Fabric for Disposal (in yards)

        [JsonPropertyName("ssyCebuFabricForDisposal")]
        public double SsyCebuFabricForDisposal { get; set; }
        [JsonPropertyName("ytiCebuFabricForDisposal")]
        public double YtiCebuFabricForDisposal { get; set; }
        [JsonPropertyName("cambodiaFabricForDisposal")]
        public double CambodiaFabricForDisposal { get; set; }
        [JsonPropertyName("gjmFabricForDisposal")]
        public double GjmFabricForDisposal { get; set; }
        [JsonPropertyName("skechersFabricForDisposal")]
        public double SkechersFabricForDisposal { get; set; }
        [JsonPropertyName("tmsFabricForDisposal")]
        public double TmsFabricForDisposal { get; set; }
        [JsonPropertyName("othersFabricForDisposal")]
        public double OthersFabricForDisposal { get; set; }

        #endregion

        #region Available Space PRE - DISPOSAL (in yards)

        [JsonPropertyName("ssyCebuAvailableSpacePreDisposal")]
        public double SsyCebuAvailableSpacePreDisposal { get; set; }
        [JsonPropertyName("ytiCebuAvailableSpacePreDisposal")]
        public double YtiCebuAvailableSpacePreDisposal { get; set; }
        [JsonPropertyName("cambodiaAvailableSpacePreDisposal")]
        public double CambodiaAvailableSpacePreDisposal { get; set; }
        [JsonPropertyName("gjmAvailableSpacePreDisposal")]
        public double GjmAvailableSpacePreDisposal { get; set; }
        [JsonPropertyName("skechersAvailableSpacePreDisposal")]
        public double SkechersAvailableSpacePreDisposal { get; set; }
        [JsonPropertyName("tmsAvailableSpacePreDisposal")]
        public double TmsAvailableSpacePreDisposal { get; set; }
        [JsonPropertyName("othersAvailableSpacePreDisposal")]
        public double OthersAvailableSpacePreDisposal { get; set; }

        #endregion

        #region Available Space POST - DISPOSAL (in yards)

        [JsonPropertyName("ssyCebuAvailableSpacePostDisposal")]
        public double SsyCebuAvailableSpacePostDisposal { get; set; }
        [JsonPropertyName("ytiCebuAvailableSpacePostDisposal")]
        public double YtiCebuAvailableSpacePostDisposal { get; set; }
        [JsonPropertyName("cambodiaAvailableSpacePostDisposal")]
        public double CambodiaAvailableSpacePostDisposal { get; set; }
        [JsonPropertyName("gjmAvailableSpacePostDisposal")]
        public double GjmAvailableSpacePostDisposal { get; set; }
        [JsonPropertyName("skechersAvailableSpacePostDisposal")]
        public double SkechersAvailableSpacePostDisposal { get; set; }
        [JsonPropertyName("tmsAvailableSpacePostDisposal")]
        public double TmsAvailableSpacePostDisposal { get; set; }
        [JsonPropertyName("othersAvailableSpacePostDisposal")]
        public double OthersAvailableSpacePostDisposal { get; set; }

        #endregion

        #region Total

        [JsonPropertyName("warehouseCapacityTotal")]
        public double WarehouseCapacityTotal { get; set; }
        [JsonPropertyName("currentTotalInventoryTotal")]
        public double CurrentTotalInventoryTotal { get; set; }
        [JsonPropertyName("reservedFabricsInventoryTotal")]
        public double ReservedFabricsInventoryTotal { get; set; }
        [JsonPropertyName("unreservedFabricsInventoryTotal")]
        public double UnreservedFabricsInventoryTotal { get; set; }
        [JsonPropertyName("incomingFabricsDeliveriesTotal")]
        public double IncomingFabricsDeliveriesTotal { get; set; }
        [JsonPropertyName("fabricForDisposalTotal")]
        public double FabricForDisposalTotal { get; set; }
        [JsonPropertyName("availableSpacePreDisposalTotal")]
        public double AvailableSpacePreDisposalTotal { get; set; }
        [JsonPropertyName("availableSpacePostDisposalTotal")]
        public double AvailableSpacePostDisposalTotal { get; set; }

        #endregion

    }

    public class WarehousePO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("poNumber")]
        public string PONumber { get; set; }
    }
}