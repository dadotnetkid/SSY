using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using SSY.Products.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Types;

public class TypeOptionDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Option> _optionRepository;
    private readonly IRepository<Type> _typeRepository;
    private readonly IRepository<TypeOption> _typeOptionRepository;

    public TypeOptionDataSeederContributor(
        IRepository<Option> optionRepository,
        IRepository<Type> typeRepository,
        IRepository<TypeOption> typeOptionRepository
        )
    {
        _optionRepository = optionRepository;
        _typeRepository = typeRepository;
        _typeOptionRepository = typeOptionRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _optionRepository.GetCountAsync() > 0
            && await _typeRepository.GetCountAsync() > 0
            && await _typeOptionRepository.GetCountAsync() <= 0)
        {

            // TODO: Serialize MaterialIds
            var zipper = new List<int>();
            zipper.Add(3001);
            var serializeZipper = JsonSerializer.Serialize(zipper);

            var bra = new List<int>();
            bra.Add(3002);
            bra.Add(3003);
            bra.Add(2005);
            var serializeBra = JsonSerializer.Serialize(bra);

            var elasticband = new List<int>();
            elasticband.Add(3004);
            var serializeElasticband = JsonSerializer.Serialize(elasticband);

            var drawcord = new List<int>();
            drawcord.Add(3005);
            var serializeDrawcord = JsonSerializer.Serialize(drawcord);

            var necktape = new List<int>();
            necktape.Add(3018);
            var serializeNecktape = JsonSerializer.Serialize(necktape);

            //var velcro = new List<string>();
            //velcro.Add("Velcro Female");
            //velcro.Add("Velcro Male");
            //var serializeVelcro = JsonSerializer.Serialize(velcro);

            //var jersey = new List<string>();
            //jersey.Add("Jersey");
            //var serializeJersey = JsonSerializer.Serialize(jersey);

            //var sweatsRib = new List<string>();
            //sweatsRib.Add("Sweats Rib");
            //var serializeSweatsRib = JsonSerializer.Serialize(sweatsRib);

            //var jerseyRib = new List<string>();
            //jerseyRib.Add("Jersey Rib");
            //var serializeJerseyRib = JsonSerializer.Serialize(jerseyRib);

            //var tiecord = new List<string>();
            //tiecord.Add("Tiecord");
            //var serializeTiecord = JsonSerializer.Serialize(tiecord);

            //var toggle = new List<string>();
            //toggle.Add("Toggle");
            //var serializeToggle = JsonSerializer.Serialize(toggle);

            //var tiecordToggle = necktape.Concat(drawcord);
            //var serializeTiecordToggle = JsonSerializer.Serialize(tiecordToggle);

            var drawcordNecktape = necktape.Concat(drawcord);
            var serializeDrawcordNecktape = JsonSerializer.Serialize(drawcordNecktape);

            //var zipperJersey = necktape.Concat(jersey);
            //var serializeZipperJersey = JsonSerializer.Serialize(zipperJersey);

            //var elasticbandDrawcord = elasticband.Concat(drawcord);
            //var serializeElasticbandDrawcord = JsonSerializer.Serialize(elasticbandDrawcord);

            //var jerseyRibNecktape = jerseyRib.Concat(necktape);
            //var serializeJerseyRibNecktape = JsonSerializer.Serialize(jerseyRibNecktape);

            //var jerseyRibDrawcord = jerseyRib.Concat(drawcord);
            //var serializeJerseyRibDrawcord = JsonSerializer.Serialize(jerseyRibDrawcord);

            //var sweatsRibNecktape = sweatsRib.Concat(necktape);
            //var serializeSweatsRibNecktape = JsonSerializer.Serialize(sweatsRibNecktape);

            #region Activewear

            #region Leggings

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 205), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 404), autoSave: true);

            //Waistband Pocket Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 604, serializeZipper), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 903), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 1207), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1001, 6506), autoSave: true);

            #endregion

            #region Capri Leggings

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 205), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 404), autoSave: true);

            //Waistband Pocket Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 604, serializeZipper), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 904), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 1207), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1063, 6506), autoSave: true);

            #endregion

            #region 2" Micro Shorts

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 205), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 404), autoSave: true);

            //Waistband Pocket Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 601, serializeZipper), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1001), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1207), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1305), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1306), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1307), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 1308), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1041, 6506), autoSave: true);

            #endregion

            #region 4" Shorts

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 205), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 404), autoSave: true);

            //Waistband Pocket Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 601, serializeZipper), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1002), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 1207), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1042, 6506), autoSave: true);

            #endregion

            #region 7" Biker

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 205), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 404), autoSave: true);

            //Waistband Pocket Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 601, serializeZipper), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1003), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 1207), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1043, 6506), autoSave: true);

            #endregion

            #region 10" Biker

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 205), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 404), autoSave: true);

            //Waistband Pocket Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 601, serializeZipper), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1004), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 1207), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1064, 6506), autoSave: true);

            #endregion

            #region Sports Bra

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 101), autoSave: true);

            //Base
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1603), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1603), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1603), autoSave: true);
            
            //Base Material Mapping (Base 1) 1044 / 1601
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1801, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1802, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1803, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1804, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1805, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1806, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1807, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1808, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1809, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1810, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1811, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1812, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1813, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1814, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1815, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1816, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1817, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1818, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1819, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1820, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1821, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1822, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1823, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1824, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1825, serializeBra), autoSave: true);

            //Base Material Mapping (Base 2) 1044 / 1602
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1826, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1827, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1828, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1829, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1830, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1831, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1832, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1833, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1834, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1835, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1836, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1837, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1838, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1839, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1840, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1841, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1842, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1843, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1844, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1845, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1846, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1847, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1848, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1849, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1850, serializeBra), autoSave: true);

            //Base Material Mapping (Base 3) 1044 / 1603
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1851, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1852, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1853, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1854, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1855, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1856, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1857, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1858, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1859, serializeBra), autoSave: true);

            //Base Material Mapping (Base 1) 1045 / 1601
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1801, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1802, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1803, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1804, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1805, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1806, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1807, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1808, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1809, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1810, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1811, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1812, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1813, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1814, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1815, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1816, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1817, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1818, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1819, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1820, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1821, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1822, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1823, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1824, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1825, serializeBra), autoSave: true);

            //Base Material Mapping (Base 2) 1045 / 1602
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1826, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1827, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1828, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1829, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1830, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1831, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1832, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1833, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1834, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1835, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1836, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1837, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1838, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1839, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1840, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1841, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1842, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1843, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1844, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1845, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1846, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1847, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1848, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1849, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1850, serializeBra), autoSave: true);

            //Base Material Mapping (Base 3) 1045 / 1603
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1851, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1852, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1853, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1854, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1855, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1856, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1857, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1858, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1859, serializeBra), autoSave: true);

            //Base Material Mapping (Base 1) 1046 / 1601
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1801, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1802, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1803, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1804, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1805, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1806, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1807, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1808, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1809, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1810, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1811, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1812, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1813, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1814, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1815, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1816, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1817, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1818, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1819, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1820, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1821, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1822, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1823, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1824, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1825, serializeBra), autoSave: true);

            //Base Material Mapping (Base 2) 1046 / 1602
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1826, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1827, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1828, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1829, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1830, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1831, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1832, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1833, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1834, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1835, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1836, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1837, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1838, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1839, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1840, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1841, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1842, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1843, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1844, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1845, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1846, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1847, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1848, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1849, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1850, serializeBra), autoSave: true);

            //Base Material Mapping (Base 3) 1046 / 1603
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1851, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1852, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1853, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1854, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1855, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1856, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1857, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1858, serializeBra), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1859, serializeBra), autoSave: true);

            //Neckline Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1904), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1905), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1906), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1907), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1908), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1904), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1905), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1906), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1907), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1908), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1904), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1905), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1906), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1907), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1908), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 14005), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 14006), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 1406), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 14005), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 14006), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 1406), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 14005), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 14006), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 1406), autoSave: true);

            //BackCutOut Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2507), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2507), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2507), autoSave: true);

            //Bustband (Parent option with material mapping)
            //Bustband Material Mapping (Base 1)
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2601, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2602, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2603, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1044, 2604, serializeElasticband), autoSave: true);

            //Bustband Material Mapping (Base 2)
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2601, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2602, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2603, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1045, 2604, serializeElasticband), autoSave: true);

            //Bustband Material Mapping (Base 3)
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2601, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2602, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2603, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 2604, serializeElasticband), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1046, 6506), autoSave: true);

            #endregion

            #region Active Tank

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 101), autoSave: true);

            //Body Length                                                      
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 3503), autoSave: true);

            //Fit                                                              
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2705), autoSave: true);

            //Bustband (Parent option with material mapping)
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2601, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2602, serializeElasticband), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2603), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2604), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2605), autoSave: true);

            //Neckline Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6304), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6305), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6306), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6307), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6308), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 14005), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 14006), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 1405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 1406), autoSave: true);

            //BackCutOut Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2507), autoSave: true);

            //Strap
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6404), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6406), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 2904), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 4401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 4402), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1006, 6506), autoSave: true);

            #endregion

            #region Active Dress

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2705), autoSave: true);

            //Body Length                                                   
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3404), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3602, serializeZipper), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3603), autoSave: true);

            //Front Opening Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3701, serializeZipper), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 3702, serializeZipper), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2004), autoSave: true);

            //Neckline Material Mapping
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2301, serializeDrawcordNecktape), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2302, serializeNecktape), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2303, serializeDrawcordNecktape), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2304, serializeNecktape), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2206, serializeNecktape), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2207, serializeNecktape), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2208, serializeNecktape), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2209, serializeNecktape), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2210, serializeNecktape), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2211, serializeNecktape), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2212, serializeNecktape), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2804), autoSave: true);

            //Sleeve Style                                                    
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4014), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4010), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1047, 6506), autoSave: true);

            #endregion

            #region Active Skirt

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 103), autoSave: true);

            //Fit                                                             
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 2705), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 905), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 906), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 907), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 908), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 4701), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 304), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 404), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 3902), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 4504), autoSave: true);

            //Inside Shorts
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 5001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 5002), autoSave: true);

            //Front Seam
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 802), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1004), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1201), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1202), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1203), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1204), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1206), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 1207), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1048, 6506), autoSave: true);

            #endregion

            #endregion

            #region Sweats

            #region Sweat Jogger

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 103), autoSave: true);

            //Fit                                                             
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 2704), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 903), autoSave: true);

            //Leg Shape
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 5701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 5702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 5703), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 4704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 4702), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 3902), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1010, 6506), autoSave: true);

            #endregion

            #region Sweat Shorts

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 103), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 103), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 2704), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 2704), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 2704), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 1101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 1102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 1103), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 1101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 1102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 1103), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 1101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 1102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 1103), autoSave: true);

            //Leg Shape
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 5701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 5703), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 5701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 5703), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 5701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 5703), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 4704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 4702), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 4704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 4702), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 4704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 4702), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1049, 3902), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1050, 3902), autoSave: true);

            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 3902), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1051, 6506), autoSave: true);

            #endregion

            #region Sweat Hoodie

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2706), autoSave: true);

            //Body Length                                                     
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3503), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3603), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2102), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 3903), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 4506), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1008, 6506), autoSave: true);

            #endregion

            #region Sweat Shirt

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 103), autoSave: true);

            //Fit   
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2704), autoSave: true);

            //Body Length   
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 3503), autoSave: true);

            //Front Opening  
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 3603), autoSave: true);

            //Neckline  
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2404), autoSave: true);

            //Sleeve Type   
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2804), autoSave: true);

            //Sleeve Style   
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 2904), autoSave: true);

            //Pocket  
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4015), autoSave: true);

            //Hem  
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 4506), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1009, 6506), autoSave: true);

            #endregion

            #region Sweat Dress

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2705), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3404), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 3603), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2004), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 1903), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4010), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4014), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 4506), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1012, 6506), autoSave: true);

            #endregion

            #region Sweat Skirt

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 2705), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 905), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 906), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 907), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 908), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 4504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 4506), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 47004), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 47002), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 3902), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1013, 6506), autoSave: true);

            #endregion

            #region Sweat Cardigan

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2705), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 3604), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 3605), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 3606), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2404), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4014), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4010), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1015, 6506), autoSave: true);

            #endregion

            #region Sweat Coat

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 103), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2705), autoSave: true);

            //Body Length                                                      
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3404), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3604), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3605), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 3606), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4014), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4010), autoSave: true);

            //Hem                                                             
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1014, 6506), autoSave: true);

            #endregion

            #region Sweat Jacket

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 103), autoSave: true);

            //Fit                                                              
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2705), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 3503), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 3602), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2404), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4014), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4010), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1016, 6506), autoSave: true);

            #endregion

            #endregion

            #region Jersey

            #region Jersey Top

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 101), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 3503), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2705), autoSave: true);

            //Bustband
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2603), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2604), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2605), autoSave: true);

            //Neckline Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6304), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6305), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6306), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6307), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6308), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 14005), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 14006), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 1405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 1406), autoSave: true);

            //BackCutOut Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2507), autoSave: true);

            //Strap
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6404), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6406), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 2904), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 4401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 4402), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1056, 6506), autoSave: true);

            #endregion

            #region Jersey Dress

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 103), autoSave: true);

            //Fit                                                             
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2705), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3404), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 3603), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2004), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4014), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4010), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1020, 6506), autoSave: true);

            #endregion

            #region Jersey Skirt

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 103), autoSave: true);

            //Fit                                                              
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 2705), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 905), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 906), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 907), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 908), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 4504), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 47004), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 47002), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 304), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 3902), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1021, 6506), autoSave: true);

            #endregion

            #region Jersey Jogger

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 103), autoSave: true);

            //Fit                                                              
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 2704), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 903), autoSave: true);

            //Leg Shape
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 5701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 5702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 5703), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 4704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 4702), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 3902), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1023, 6506), autoSave: true);

            #endregion

            #region Jersey Shorts

            ////Gender
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1047, 101),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 102),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 103),autoSave:true);

            ////Fit                                                              
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 2706),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 2702),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 2703),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 2704),autoSave:true);

            ////Length
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 1101),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 1102),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 1103),autoSave:true);

            ////Leg Shape
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 5701),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 5703),autoSave:true);

            ////Waistband Style
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 4704),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 4702),autoSave:true);

            ////Pocket
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 3901),autoSave:true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(  1024, 3902),autoSave:true);

            ////Outside Branding
            //await _typeOptionRepository.InsertAsync(new TypeOption(1024, 6505), autoSave: true);
            //await _typeOptionRepository.InsertAsync(new TypeOption(1024, 6506), autoSave: true);

            #endregion

            #region Jersey Hoodie

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 103), autoSave: true);

            //Fit                                                              
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2704), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3503), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3603), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2102), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 3903), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1022, 6506), autoSave: true);

            #endregion

            #endregion

            #region Windbreakers

            #region Windbreaker Jogger/Pants

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 103), autoSave: true);

            //Fit                                                             
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 2704), autoSave: true);

            //Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 901), autoSave: true);

            //Leg Shape
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 5701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 5702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 5703), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 4702), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 3901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 3902), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1040, 6506), autoSave: true);

            #endregion

            #region Windbreaker Shorts

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 202), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 304), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 4705), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 4702), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 404), autoSave: true);

            //Inside Short Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 5305), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 5306), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 5307), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 5308), autoSave: true);

            //Inside Short Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6004), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6005), autoSave: true);

            //Outside Shorts
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6201), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1057, 6506), autoSave: true);

            #endregion

            #region Windbreaker Jacket

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 101), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 102), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 103), autoSave: true);

            //Fit                                                              
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2706), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2704), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3503), autoSave: true);

            //Front Opening
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3603), autoSave: true);

            //Neckline
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 1903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2304), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 2904), autoSave: true);

            //Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 3903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4013), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4011), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4012), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4014), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4009), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4010), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 4504), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1038, 6506), autoSave: true);

            #endregion

            #endregion

            #region Mesh

            #region Mesh Top

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 101), autoSave: true);

            //Body Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 3501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 3502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 3503), autoSave: true);

            //Fit
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2701), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2702), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2704), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2705), autoSave: true);

            //Bustband
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2601), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2602), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2603), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2604), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2605), autoSave: true);

            //Neckline Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6304), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6305), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6306), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6307), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6308), autoSave: true);

            //Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 14005), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 14006), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 1405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 1406), autoSave: true);

            //BackCutOut Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2504), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2506), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2507), autoSave: true);

            //Strap
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6404), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6405), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6406), autoSave: true);

            //Sleeve Type
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2801), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2802), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2803), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2804), autoSave: true);

            //Sleeve Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2901), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2902), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2903), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 2904), autoSave: true);

            //Hem
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 4401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 4402), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1059, 6506), autoSave: true);

            #endregion

            #region Mesh Running Shorts

            //Gender
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 101), autoSave: true);

            //Rise
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 205), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 202), autoSave: true);

            //Waistband
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 301), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 302), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 303), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 304), autoSave: true);

            //Waistband Style
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 4703), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 4702), autoSave: true);

            //Waistband Pocket
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 401), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 402), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 403), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 404), autoSave: true);

            //Inside Short Length
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6501), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6502), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6503), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6504), autoSave: true);

            //Inside Short Panel
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6001), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6002), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6003), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6004), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6005), autoSave: true);

            //Outside Shorts
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6202), autoSave: true);

            //Outside Branding
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6505), autoSave: true);
            await _typeOptionRepository.InsertAsync(new TypeOption(1055, 6506), autoSave: true);

            #endregion

            #endregion

        }
    }
}