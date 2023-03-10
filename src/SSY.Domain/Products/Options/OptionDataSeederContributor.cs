using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Options;

public class OptionDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Option, int> _optionRepository;

    public OptionDataSeederContributor(IRepository<Option, int> optionRepository)
    {
        _optionRepository = optionRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _optionRepository.GetCountAsync() <= 0)
        {
            await _optionRepository.InsertAsync(new Option(101, true, "Gender", "Female", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(102, true, "Gender", "Male", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(103, true, "Gender", "Unisex", 1003, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(201, true, "Rise", "Slim", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(202, true, "Rise", "Regular", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(203, true, "Rise", "Oversized", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(204, true, "Rise", "Loose", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(205, true, "Rise", "High", 1005, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(301, true, "Waistband", "5cm", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(302, true, "Waistband", "8cm", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(303, true, "Waistband", "10cm", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(304, true, "Waistband", "12cm", 1004, false), autoSave: true);

            #region Waistband Pocket

            await _optionRepository.InsertAsync(new Option(401, true, "Waistband Pocket", "Front Left", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(402, true, "Waistband Pocket", "Back Center", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(403, true, "Waistband Pocket", "Back Waist Pocket", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(404, true, "Waistband Pocket", "No Pocket", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(501, true, "Waistband Pocket", "With Zipper", 1001, false, 402), autoSave: true);
            await _optionRepository.InsertAsync(new Option(502, true, "Waistband Pocket", "Welt", 1001, false, 402), autoSave: true);

            await _optionRepository.InsertAsync(new Option(601, true, "Waistband Pocket", "6\" Zipper", 1001, false, 501), autoSave: true);
            await _optionRepository.InsertAsync(new Option(602, true, "Waistband Pocket", "6\" Zipper", 1001, false, 601), autoSave: true);

            //await _optionRepository.InsertAsync(new Option(603,true, "Waistband Pocket", "6\" Zipper", 1001, false, 501), autoSave: true);

            await _optionRepository.InsertAsync(new Option(701, true, "Waistband Pocket", "Black", 1001, false, 601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(702, true, "Waistband Pocket", "White", 1002, false, 601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(703, true, "Waistband Pocket", "Grey", 1003, false, 601), autoSave: true);

            await _optionRepository.InsertAsync(new Option(405, true, "Waistband Pocket", "Back Center", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(503, true, "Waistband Pocket", "Welt", 1001, false, 405), autoSave: true);
            await _optionRepository.InsertAsync(new Option(604, true, "Waistband Pocket", "6\" Zipper", 1001, false, 405), autoSave: true);

            #endregion

            await _optionRepository.InsertAsync(new Option(801, true, "Front Seam", "Yes", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(802, true, "Front Seam", "No", 1002, false), autoSave: true);

            //============ Length ============

            await _optionRepository.InsertAsync(new Option(901, true, "Length", "Full Length", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(902, true, "Length", "7/8", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(903, true, "Length", "3/4", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(904, true, "Length", "Capri", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(905, true, "Length", "Mini", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(906, true, "Length", "Midi", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(907, true, "Length", "3/4", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(908, true, "Length", "Maxi", 1004, false), autoSave: true);


            await _optionRepository.InsertAsync(new Option(1001, true, "Length", "2\" Micro", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1002, true, "Length", "4\" Short", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1003, true, "Length", "7\" Biker", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1004, true, "Length", "10\" Biker", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1101, true, "Length", "3\" Inseam", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1102, true, "Length", "5\" Inseam", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1103, true, "Length", "7\" Inseam", 1003, false), autoSave: true);


            await _optionRepository.InsertAsync(new Option(1201, true, "Panel", "L Full Side", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1202, true, "Panel", "R Full Side", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1203, true, "Panel", "L Panel", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1204, true, "Panel", "R Panel", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1205, true, "Panel", "Regular Side Seam", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1206, true, "Panel", "No Side Seam", 1006, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1207, true, "Panel", "Other Design Options", 1007, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1301, true, "Panel", "With Pocket", 1001, true, 1201), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1302, true, "Panel", "No Pocket", 1002, true, 1201), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1303, true, "Panel", "With Pocket", 1001, true, 1202), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1304, true, "Panel", "No Pocket", 1002, true, 1202), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1305, true, "Panel", "Front Thigh", 1001, true, 1203), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1306, true, "Panel", "Back Thigh", 1002, true, 1203), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1307, true, "Panel", "Front Thigh", 1001, true, 1204), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1308, true, "Panel", "Back Thigh", 1002, true, 1204), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1401, true, "Panel", "Front", 1001, false, 1203), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1402, true, "Panel", "Back", 1002, false, 1203), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1403, true, "Panel", "Front", 1001, false, 1204), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1404, true, "Panel", "Back", 1002, false, 1204), autoSave: true);

            await _optionRepository.InsertAsync(new Option(14005, true, "Panel", "Front Panel", 1001, true), autoSave: true);
            await _optionRepository.InsertAsync(new Option(14006, true, "Panel", "Back Panel", 1002, true), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1405, true, "Panel", "No Panel", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1406, true, "Panel", "Side Panel", 1004, true), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1501, true, "Panel", "Thigh Position", 1001, true, 1401), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1502, true, "Panel", "Calf Position", 1002, true, 1401), autoSave: true);
            await _optionRepository.InsertAsync(new Option(15003, true, "Panel", "Shin Position", 1003, true, 1401), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1503, true, "Panel", "Thigh Position", 1001, true, 1402), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1504, true, "Panel", "Calf Position", 1002, true, 1402), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1505, true, "Panel", "Thigh Position", 1001, true, 1403), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1506, true, "Panel", "Calf Position", 1002, true, 1403), autoSave: true);
            await _optionRepository.InsertAsync(new Option(15004, true, "Panel", "Shin Position", 1003, true, 1403), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1507, true, "Panel", "Thigh Position", 1001, true, 1404), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1508, true, "Panel", "Calf Position", 1002, true, 1404), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1601, true, "Base", "Base 1", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1602, true, "Base", "Base 2", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1603, true, "Base", "Base 3", 1003, false), autoSave: true);


            await _optionRepository.InsertAsync(new Option(1701, true, "Base", "High Neckline", 1001, false, 1601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1702, true, "Base", "Medium Neckline", 1002, false, 1601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1703, true, "Base", "Regular Neckline", 1003, false, 1601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1704, true, "Base", "Low Neckline", 1004, false, 1601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1705, true, "Base", "Super Low Neckline", 1005, false, 1601), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1801, true, "Base", "0.4\" Strap", 1001, false, 1701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1802, true, "Base", "0.8\" Strap", 1002, false, 1701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1803, true, "Base", "1\" Strap", 1003, false, 1701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1804, true, "Base", "1.5\" Strap", 1004, false, 1701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1805, true, "Base", "2\" Strap", 1005, false, 1701), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1806, true, "Base", "0.4\" Strap", 1001, false, 1702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1807, true, "Base", "0.8\" Strap", 1002, false, 1702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1808, true, "Base", "1\" Strap", 1003, false, 1702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1809, true, "Base", "1.5\" Strap", 1004, false, 1702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1810, true, "Base", "2\" Strap", 1005, false, 1702), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1811, true, "Base", "0.4\" Strap", 1001, false, 1703), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1812, true, "Base", "0.8\" Strap", 1002, false, 1703), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1813, true, "Base", "1\" Strap", 1003, false, 1703), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1814, true, "Base", "1.5\" Strap", 1004, false, 1703), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1815, true, "Base", "2\" Strap", 1005, false, 1703), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1816, true, "Base", "0.4\" Strap", 1001, false, 1704), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1817, true, "Base", "0.8\" Strap", 1002, false, 1704), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1818, true, "Base", "1\" Strap", 1003, false, 1704), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1819, true, "Base", "1.5\" Strap", 1004, false, 1704), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1820, true, "Base", "2\" Strap", 1005, false, 1704), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1821, true, "Base", "0.4\" Strap", 1001, false, 1705), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1822, true, "Base", "0.8\" Strap", 1002, false, 1705), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1823, true, "Base", "1\" Strap", 1003, false, 1705), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1824, true, "Base", "1.5\" Strap", 1004, false, 1705), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1825, true, "Base", "2\" Strap", 1005, false, 1705), autoSave: true);


            await _optionRepository.InsertAsync(new Option(1706, true, "Base", "High Neckline", 1001, false, 1602), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1707, true, "Base", "Medium Neckline", 1002, false, 1602), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1708, true, "Base", "Regular Neckline", 1003, false, 1602), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1709, true, "Base", "Low Neckline", 1004, false, 1602), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1710, true, "Base", "Super Low Neckline", 1005, false, 1602), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1826, true, "Base", "0.4\" Strap", 1001, false, 1706), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1827, true, "Base", "0.8\" Strap", 1002, false, 1706), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1828, true, "Base", "1\" Strap", 1003, false, 1706), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1829, true, "Base", "1.5\" Strap", 1004, false, 1706), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1830, true, "Base", "2\" Strap", 1005, false, 1706), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1831, true, "Base", "0.4\" Strap", 1001, false, 1707), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1832, true, "Base", "0.8\" Strap", 1002, false, 1707), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1833, true, "Base", "1\" Strap", 1003, false, 1707), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1834, true, "Base", "1.5\" Strap", 1004, false, 1707), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1835, true, "Base", "2\" Strap", 1005, false, 1707), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1836, true, "Base", "0.4\" Strap", 1001, false, 1708), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1837, true, "Base", "0.8\" Strap", 1002, false, 1708), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1838, true, "Base", "1\" Strap", 1003, false, 1708), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1839, true, "Base", "1.5\" Strap", 1004, false, 1708), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1840, true, "Base", "2\" Strap", 1005, false, 1708), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1841, true, "Base", "0.4\" Strap", 1001, false, 1709), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1842, true, "Base", "0.8\" Strap", 1002, false, 1709), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1843, true, "Base", "1\" Strap", 1003, false, 1709), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1844, true, "Base", "1.5\" Strap", 1004, false, 1709), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1845, true, "Base", "2\" Strap", 1005, false, 1709), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1846, true, "Base", "0.4\" Strap", 1001, false, 1710), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1847, true, "Base", "0.8\" Strap", 1002, false, 1710), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1848, true, "Base", "1\" Strap", 1003, false, 1710), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1849, true, "Base", "1.5\" Strap", 1004, false, 1710), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1850, true, "Base", "2\" Strap", 1005, false, 1710), autoSave: true);


            await _optionRepository.InsertAsync(new Option(1711, true, "Base", "High Neckline", 1001, false, 1603), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1712, true, "Base", "Medium Neckline", 1002, false, 1603), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1713, true, "Base", "Regular Neckline", 1003, false, 1603), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1851, true, "Base", "1\" Strap", 1003, false, 1711), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1852, true, "Base", "1.5\" Strap", 1004, false, 1711), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1853, true, "Base", "2\" Strap", 1005, false, 1711), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1854, true, "Base", "1\" Strap", 1003, false, 1712), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1855, true, "Base", "1.5\" Strap", 1004, false, 1712), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1856, true, "Base", "2\" Strap", 1005, false, 1712), autoSave: true);

            await _optionRepository.InsertAsync(new Option(1857, true, "Base", "1\" Strap", 1003, false, 1713), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1858, true, "Base", "1.5\" Strap", 1004, false, 1713), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1859, true, "Base", "2\" Strap", 1005, false, 1713), autoSave: true);


            #region Neckline

            await _optionRepository.InsertAsync(new Option(1901, true, "Neckline", "Round", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1902, true, "Neckline", "Square", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1903, true, "Neckline", "V-Neck", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1904, true, "Neckline", "Halter Neck", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1905, true, "Neckline", "Straight Across", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1906, true, "Neckline", "Sweet Heart", 1006, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1907, true, "Neckline", "Boat Neck", 1007, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(1908, true, "Neckline", "Asymmetric", 1008, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2001, true, "Neckline", "Hooded", 1009, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2002, true, "Neckline", "Crew Neck", 1010, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2003, true, "Neckline", "Wide Neck", 1011, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2004, true, "Neckline", "High Neck", 1012, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2201, true, "Neckline", "Fabric Neckline", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2202, true, "Neckline", "Clean Finish Neckline", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2203, true, "Neckline", "Fabric Collar", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2204, true, "Neckline", "Ribbed Neckline", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2205, true, "Neckline", "Raw Edge", 1005, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2401, true, "Neckline", "Regular Hoodie", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2402, true, "Neckline", "Cross Over Hoodie", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2403, true, "Neckline", "Stand-Up Collar", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2404, true, "Neckline", "Mandarin Collar", 1001, false), autoSave: true);


            //====== Hooded ========
            await _optionRepository.InsertAsync(new Option(2101, true, "Neckline", "Regular", 1001, false, 2001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2102, true, "Neckline", "Cross Over", 1002, false, 2001), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2301, true, "Neckline", "With Drawcord", 1001, false, 2101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2302, true, "Neckline", "No Drawcord", 1002, false, 2101), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2303, true, "Neckline", "With Drawcord", 1001, false, 2102), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2304, true, "Neckline", "No Drawcord", 1002, false, 2102), autoSave: true);


            //====== Crew Neck ========
            await _optionRepository.InsertAsync(new Option(2206, true, "Neckline", "Fabric Neckline", 1001, false, 2002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2207, true, "Neckline", "Clean Finish Neckline", 1002, false, 2002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2215, true, "Neckline", "Ribbed Neckline", 1003, false, 2002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2216, true, "Neckline", "Raw Edge", 1004, false, 2002), autoSave: true);


            //====== V Neck ========
            await _optionRepository.InsertAsync(new Option(2208, true, "Neckline", "Fabric Neckline", 1001, false, 1903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2209, true, "Neckline", "Clean Finish Neckline", 1002, false, 1903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2217, true, "Neckline", "Ribbed Neckline", 1003, false, 1903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2218, true, "Neckline", "Raw Edge", 1004, false, 1903), autoSave: true);


            //====== Wide Neck ========
            await _optionRepository.InsertAsync(new Option(2210, true, "Neckline", "Fabric Neckline", 1001, false, 2003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2211, true, "Neckline", "Clean Finish Neckline", 1002, false, 2003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2219, true, "Neckline", "Ribbed Neckline", 1003, false, 2003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2220, true, "Neckline", "Raw Edge", 1004, false, 2003), autoSave: true);


            //====== Regular Hoodie ==========
            await _optionRepository.InsertAsync(new Option(2305, true, "Neckline", "With Drawcord", 1001, false, 2401), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2306, true, "Neckline", "No Drawcord", 1002, false, 2401), autoSave: true);


            //====== Cross Over Hoodie ========
            await _optionRepository.InsertAsync(new Option(2307, true, "Neckline", "With Drawcord", 1001, false, 2402), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2308, true, "Neckline", "No Drawcord", 1002, false, 2402), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2213, true, "Neckline", "Fabric Collar", 1001, false, 2403), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2214, true, "Neckline", "Fabric Collar", 1001, false, 2404), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2290, true, "Neckline", "Ribbed Collar", 1002, false, 2403), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2291, true, "Neckline", "Ribbed Collar", 1002, false, 2404), autoSave: true);

            //====== High Neck ========
            await _optionRepository.InsertAsync(new Option(2212, true, "Neckline", "Fabric Neckline", 1001, false, 2004), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2221, true, "Neckline", "Ribbed Neckline", 1003, false, 2004), autoSave: true);


            #endregion


            await _optionRepository.InsertAsync(new Option(2501, true, "BackCutOut Style", "High Back", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2502, true, "BackCutOut Style", "RacerBack", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2503, true, "BackCutOut Style", "Low RacerBack", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2504, true, "BackCutOut Style", "Hourglass Back", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2505, true, "BackCutOut Style", "Strap Crossed", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2506, true, "BackCutOut Style", "Strap Straight", 1006, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2507, true, "BackCutOut Style", "Cami Back", 1007, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2601, true, "Bustband", "1\"", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2602, true, "Bustband", "1.5\"", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2603, true, "Bustband", "2\"", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2604, true, "Bustband", "2.5\"", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2605, true, "Bustband", "No", 1005, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(2701, true, "Fit", "Fitted", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2702, true, "Fit", "Regular", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2703, true, "Fit", "Oversized", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2704, true, "Fit", "Loose", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2705, true, "Fit", "A Line", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2706, true, "Fit", "Slim", 1006, false), autoSave: true);


            await _optionRepository.InsertAsync(new Option(2801, true, "Sleeve Type", "Set-In Sleeve", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2802, true, "Sleeve Type", "Raglan Sleeve", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2803, true, "Sleeve Type", "Drop Shoulder Sleeve", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2804, true, "Sleeve Type", "Dolman", 1004, false), autoSave: true);


            #region Sleeve Style

            await _optionRepository.InsertAsync(new Option(2901, true, "Sleeve Style", "Sleeveless", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2902, true, "Sleeve Style", "Short Sleeve", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2903, true, "Sleeve Style", "3/4 Sleeve", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(2904, true, "Sleeve Style", "Long Sleeve", 1004, false), autoSave: true);


            //============ Sleeve Style : Short Sleeve ====================

            await _optionRepository.InsertAsync(new Option(3202, true, "Sleeve Style", "Fabric Cuff", 1001, false, 2902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3203, true, "Sleeve Style", "Elastic Cuff", 1002, false, 2902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3011, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 2902), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3239, true, "Sleeve Style", "0.5\"", 1001, false, 3202), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3240, true, "Sleeve Style", "1\"", 1002, false, 3202), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3241, true, "Sleeve Style", "0.5\"", 1001, false, 3203), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3242, true, "Sleeve Style", "1\"", 1002, false, 3203), autoSave: true);


            //============ Sleeve Style : 3/4 Sleeve ====================

            await _optionRepository.InsertAsync(new Option(3001, true, "Sleeve Style", "Regular", 1001, false, 2903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3002, true, "Sleeve Style", "Oversized", 1002, false, 2903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3003, true, "Sleeve Style", "Balloon", 1003, false, 2903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3004, true, "Sleeve Style", "Flare", 1004, false, 2903), autoSave: true);

            //Mesh Top
            await _optionRepository.InsertAsync(new Option(30010, true, "Sleeve Style", "Clean Finish", 1001, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(30020, true, "Sleeve Style", "Clean Finish", 1002, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(30030, true, "Sleeve Style", "Clean Finish", 1003, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(30040, true, "Sleeve Style", "Clean Finish", 1004, false, 3004), autoSave: true);


            //============ Sleeve Style : Long Sleeve ====================

            await _optionRepository.InsertAsync(new Option(3005, true, "Sleeve Style", "Regular", 1001, false, 2904), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3006, true, "Sleeve Style", "Oversized", 1002, false, 2904), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3007, true, "Sleeve Style", "Balloon", 1003, false, 2904), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3008, true, "Sleeve Style", "Flare", 1004, false, 2904), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3012, true, "Sleeve Style", "Clean Finish", 1001, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3013, true, "Sleeve Style", "Clean Finish", 1001, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3014, true, "Sleeve Style", "Clean Finish", 1001, false, 3004), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3101, true, "Sleeve Style", "With Thumbhole", 1001, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3102, true, "Sleeve Style", "No Thumbhole", 1002, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(30012, true, "Sleeve Style", "Clean Finish", 1001, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(30013, true, "Sleeve Style", "Clean Finish", 1001, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(30014, true, "Sleeve Style", "Clean Finish", 1001, false, 3008), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3015, true, "Sleeve Style", "Clean Finish", 1001, false, 3101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3016, true, "Sleeve Style", "Clean Finish", 1001, false, 3102), autoSave: true);

            #region Sleeve Style (Jersey Dress)

            //============ Sleeveless ================
            await _optionRepository.InsertAsync(new Option(3201, true, "Sleeve Style", "Clean Finish Hem", 1001, false, 2901), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3205, true, "Sleeve Style", "Raw Edge", 1002, false, 2901), autoSave: true);

            //============ Short Sleeve ================
            await _optionRepository.InsertAsync(new Option(3017, true, "Sleeve Style", "Fabric Cuff", 1001, false, 2902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3018, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 2902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3019, true, "Sleeve Style", "Elastic Cuff", 1003, false, 2902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3020, true, "Sleeve Style", "Clean Finish Hem", 1004, false, 2902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3021, true, "Sleeve Style", "Raw Edge", 1005, false, 2902), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3022, true, "Sleeve Style", "0.5\"", 1001, false, 3017), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3023, true, "Sleeve Style", "1\"", 1002, false, 3017), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3024, true, "Sleeve Style", "0.5\"", 1001, false, 3018), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3025, true, "Sleeve Style", "1\"", 1002, false, 3018), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3026, true, "Sleeve Style", "0.5\"", 1001, false, 3019), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3027, true, "Sleeve Style", "1\"", 1002, false, 3019), autoSave: true);

            //============ 3/4 Sleeve : Regular ====================

            await _optionRepository.InsertAsync(new Option(32007, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(39001, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32008, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32009, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(39002, true, "Sleeve Style", "Raw Edge", 1005, false, 3001), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32100, true, "Sleeve Style", "0.5\"", 1001, false, 32007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32101, true, "Sleeve Style", "1\"", 1002, false, 32007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32102, true, "Sleeve Style", "2\"", 1003, false, 32007), autoSave: true);

            await _optionRepository.InsertAsync(new Option(39003, true, "Sleeve Style", "0.5\"", 1001, false, 39001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3904, true, "Sleeve Style", "1\"", 1002, false, 39001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3905, true, "Sleeve Style", "2\"", 1003, false, 39001), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32103, true, "Sleeve Style", "0.5\"", 1001, false, 32008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32104, true, "Sleeve Style", "1\"", 1002, false, 32008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32105, true, "Sleeve Style", "2\"", 1003, false, 32008), autoSave: true);


            //============ 3/4 Sleeve : Oversized ====================

            await _optionRepository.InsertAsync(new Option(32106, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3906, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32107, true, "Sleeve Style", "Elastic Cuff", 1003, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32108, true, "Sleeve Style", "Clean Finish Hem", 1004, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3907, true, "Sleeve Style", "Raw Edge", 1005, false, 3002), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32109, true, "Sleeve Style", "0.5\"", 1001, false, 32106), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32200, true, "Sleeve Style", "1\"", 1002, false, 32106), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32201, true, "Sleeve Style", "2\"", 1003, false, 32106), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3908, true, "Sleeve Style", "0.5\"", 1001, false, 3906), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3909, true, "Sleeve Style", "1\"", 1002, false, 3906), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3910, true, "Sleeve Style", "2\"", 1003, false, 3906), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32202, true, "Sleeve Style", "0.5\"", 1001, false, 32107), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32203, true, "Sleeve Style", "1\"", 1002, false, 32107), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32204, true, "Sleeve Style", "2\"", 1003, false, 32107), autoSave: true);


            //============ 3/4 Sleeve : Balloon ====================

            await _optionRepository.InsertAsync(new Option(32205, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3911, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32206, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32207, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3912, true, "Sleeve Style", "Raw Edge", 1005, false, 3003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32208, true, "Sleeve Style", "0.5\"", 1001, false, 32205), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32209, true, "Sleeve Style", "1\"", 1002, false, 32205), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32300, true, "Sleeve Style", "2\"", 1003, false, 32205), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3913, true, "Sleeve Style", "0.5\"", 1001, false, 3911), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3914, true, "Sleeve Style", "1\"", 1002, false, 3911), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3915, true, "Sleeve Style", "2\"", 1003, false, 3911), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32301, true, "Sleeve Style", "0.5\"", 1001, false, 32206), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32302, true, "Sleeve Style", "1\"", 1002, false, 32206), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32303, true, "Sleeve Style", "2\"", 1003, false, 32206), autoSave: true);


            //============ 3/4 Sleeve : Flare ====================

            await _optionRepository.InsertAsync(new Option(32304, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3004), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3916, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3004), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32305, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3004), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3917, true, "Sleeve Style", "Raw Edge", 1005, false, 3003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(32306, true, "Sleeve Style", "0.5\"", 1001, false, 32304), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32307, true, "Sleeve Style", "1\"", 1002, false, 32304), autoSave: true);
            await _optionRepository.InsertAsync(new Option(32308, true, "Sleeve Style", "2\"", 1003, false, 32304), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3918, true, "Sleeve Style", "0.5\"", 1001, false, 3916), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3919, true, "Sleeve Style", "1\"", 1002, false, 3916), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3920, true, "Sleeve Style", "2\"", 1003, false, 3916), autoSave: true);



            //============ Longsleeve : Regular ====================

            await _optionRepository.InsertAsync(new Option(33007, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3921, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3004), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33008, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33009, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3922, true, "Sleeve Style", "Raw Edge", 1005, false, 3003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(33109, true, "Sleeve Style", "0.5\"", 1001, false, 33007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33200, true, "Sleeve Style", "1\"", 1002, false, 33007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33201, true, "Sleeve Style", "2\"", 1003, false, 33007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33202, true, "Sleeve Style", "3\"", 1004, false, 33007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33203, true, "Sleeve Style", "4\"", 1005, false, 33007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33204, true, "Sleeve Style", "5\"", 1006, false, 33007), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3923, true, "Sleeve Style", "0.5\"", 1001, false, 3921), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3924, true, "Sleeve Style", "1\"", 1002, false, 3921), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3925, true, "Sleeve Style", "2\"", 1003, false, 3921), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3926, true, "Sleeve Style", "3\"", 1004, false, 3921), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3927, true, "Sleeve Style", "4\"", 1005, false, 3921), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3928, true, "Sleeve Style", "5\"", 1006, false, 3921), autoSave: true);

            await _optionRepository.InsertAsync(new Option(33205, true, "Sleeve Style", "0.5\"", 1001, false, 33008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33206, true, "Sleeve Style", "1\"", 1002, false, 33008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33207, true, "Sleeve Style", "2\"", 1003, false, 33008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33208, true, "Sleeve Style", "3\"", 1004, false, 33008), autoSave: true);


            //============ Longsleeve : Oversized ====================

            await _optionRepository.InsertAsync(new Option(33100, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3929, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33101, true, "Sleeve Style", "Elastic Cuff", 1003, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33102, true, "Sleeve Style", "Clean Finish Hem", 1004, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3930, true, "Sleeve Style", "Raw Edge", 1005, false, 3006), autoSave: true);

            await _optionRepository.InsertAsync(new Option(33209, true, "Sleeve Style", "0.5\"", 1001, false, 33100), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33300, true, "Sleeve Style", "1\"", 1002, false, 33100), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33301, true, "Sleeve Style", "2\"", 1003, false, 33100), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33302, true, "Sleeve Style", "3\"", 1004, false, 33100), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33303, true, "Sleeve Style", "4\"", 1005, false, 33100), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33304, true, "Sleeve Style", "5\"", 1006, false, 33100), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3931, true, "Sleeve Style", "0.5\"", 1001, false, 3929), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3932, true, "Sleeve Style", "1\"", 1002, false, 3929), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3933, true, "Sleeve Style", "2\"", 1003, false, 3929), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3934, true, "Sleeve Style", "3\"", 1004, false, 3929), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3935, true, "Sleeve Style", "4\"", 1005, false, 3929), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3936, true, "Sleeve Style", "5\"", 1006, false, 3929), autoSave: true);

            await _optionRepository.InsertAsync(new Option(33305, true, "Sleeve Style", "0.5\"", 1001, false, 33101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33306, true, "Sleeve Style", "1\"", 1002, false, 33101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33307, true, "Sleeve Style", "2\"", 1003, false, 33101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33308, true, "Sleeve Style", "3\"", 1004, false, 33101), autoSave: true);


            //============ Longsleeve : Balloon ====================

            await _optionRepository.InsertAsync(new Option(33103, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3937, true, "Sleeve Style", "Ribbed Cuff", 1002, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33104, true, "Sleeve Style", "Elastic Cuff", 1003, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33105, true, "Sleeve Style", "Clean Finish Hem", 1004, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3938, true, "Sleeve Style", "Raw Edge", 1005, false, 3007), autoSave: true);

            await _optionRepository.InsertAsync(new Option(33309, true, "Sleeve Style", "0.5\"", 1001, false, 33103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33400, true, "Sleeve Style", "1\"", 1002, false, 33103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33401, true, "Sleeve Style", "2\"", 1003, false, 33103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33402, true, "Sleeve Style", "3\"", 1004, false, 33103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33403, true, "Sleeve Style", "4\"", 1005, false, 33103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33404, true, "Sleeve Style", "5\"", 1006, false, 33103), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3939, true, "Sleeve Style", "0.5\"", 1001, false, 3937), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3940, true, "Sleeve Style", "1\"", 1002, false, 3937), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3941, true, "Sleeve Style", "2\"", 1003, false, 3937), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3942, true, "Sleeve Style", "3\"", 1004, false, 3937), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3943, true, "Sleeve Style", "4\"", 1005, false, 3937), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3944, true, "Sleeve Style", "5\"", 1006, false, 3937), autoSave: true);

            await _optionRepository.InsertAsync(new Option(33405, true, "Sleeve Style", "0.5\"", 1001, false, 33104), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33406, true, "Sleeve Style", "1\"", 1002, false, 33104), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33407, true, "Sleeve Style", "2\"", 1003, false, 33104), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33408, true, "Sleeve Style", "3\"", 1004, false, 33104), autoSave: true);


            //============ Longsleeve : Flare ====================

            await _optionRepository.InsertAsync(new Option(3945, true, "Sleeve Style", "Ribbed Cuff", 1001, false, 3008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33107, true, "Sleeve Style", "Clean Finish Hem", 1002, false, 3008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(33108, true, "Sleeve Style", "Raw Edge", 1003, false, 3008), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3946, true, "Sleeve Style", "0.5\"", 1001, false, 3945), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3947, true, "Sleeve Style", "1\"", 1002, false, 3945), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3948, true, "Sleeve Style", "2\"", 1003, false, 3945), autoSave: true);

            #endregion


            //============ Sleeve Style : 3/4 Sleeve : Regular ====================

            await _optionRepository.InsertAsync(new Option(3207, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3208, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3209, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3001), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3210, true, "Sleeve Style", "0.5\"", 1001, false, 3207), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3211, true, "Sleeve Style", "1\"", 1002, false, 3207), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3212, true, "Sleeve Style", "2\"", 1003, false, 3207), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3213, true, "Sleeve Style", "0.5\"", 1001, false, 3208), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3214, true, "Sleeve Style", "1\"", 1002, false, 3208), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3215, true, "Sleeve Style", "2\"", 1003, false, 3208), autoSave: true);


            //============ Sleeve Style : 3/4 Sleeve : Oversized ====================

            await _optionRepository.InsertAsync(new Option(3216, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3217, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3218, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3002), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3219, true, "Sleeve Style", "0.5\"", 1001, false, 3216), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3220, true, "Sleeve Style", "1\"", 1002, false, 3216), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3221, true, "Sleeve Style", "2\"", 1003, false, 3216), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3222, true, "Sleeve Style", "0.5\"", 1001, false, 3217), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3223, true, "Sleeve Style", "1\"", 1002, false, 3217), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3224, true, "Sleeve Style", "2\"", 1003, false, 3217), autoSave: true);


            //============ Sleeve Style : 3/4 Sleeve : Balloon ====================

            await _optionRepository.InsertAsync(new Option(3225, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3226, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3227, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3228, true, "Sleeve Style", "0.5\"", 1001, false, 3221), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3229, true, "Sleeve Style", "1\"", 1002, false, 3221), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3230, true, "Sleeve Style", "2\"", 1003, false, 3221), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3231, true, "Sleeve Style", "0.5\"", 1001, false, 3222), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3232, true, "Sleeve Style", "1\"", 1002, false, 3222), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3233, true, "Sleeve Style", "2\"", 1003, false, 3222), autoSave: true);


            //============ Sleeve Style : 3/4 Sleeve : Flare ====================

            await _optionRepository.InsertAsync(new Option(3234, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3004), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3235, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3004), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3236, true, "Sleeve Style", "0.5\"", 1001, false, 3234), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3237, true, "Sleeve Style", "1\"", 1002, false, 3234), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3238, true, "Sleeve Style", "2\"", 1003, false, 3234), autoSave: true);


            //============ Sleeve Style : Longsleeve : Regular ====================

            await _optionRepository.InsertAsync(new Option(3307, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3308, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3309, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3005), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3319, true, "Sleeve Style", "0.5\"", 1001, false, 3307), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3320, true, "Sleeve Style", "1\"", 1002, false, 3307), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3321, true, "Sleeve Style", "2\"", 1003, false, 3307), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3322, true, "Sleeve Style", "3\"", 1004, false, 3307), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3323, true, "Sleeve Style", "4\"", 1005, false, 3307), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3324, true, "Sleeve Style", "5\"", 1006, false, 3307), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3325, true, "Sleeve Style", "0.5\"", 1001, false, 3308), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3326, true, "Sleeve Style", "1\"", 1002, false, 3308), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3327, true, "Sleeve Style", "2\"", 1003, false, 3308), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3328, true, "Sleeve Style", "3\"", 1004, false, 3308), autoSave: true);


            //============ Sleeve Style : Longsleeve : Oversized ====================

            await _optionRepository.InsertAsync(new Option(3310, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3311, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3312, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3006), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3329, true, "Sleeve Style", "0.5\"", 1001, false, 3310), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3330, true, "Sleeve Style", "1\"", 1002, false, 3310), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3331, true, "Sleeve Style", "2\"", 1003, false, 3310), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3332, true, "Sleeve Style", "3\"", 1004, false, 3310), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3333, true, "Sleeve Style", "4\"", 1005, false, 3310), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3334, true, "Sleeve Style", "5\"", 1006, false, 3310), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3335, true, "Sleeve Style", "0.5\"", 1001, false, 3311), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3336, true, "Sleeve Style", "1\"", 1002, false, 3311), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3337, true, "Sleeve Style", "2\"", 1003, false, 3311), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3338, true, "Sleeve Style", "3\"", 1004, false, 3311), autoSave: true);


            //============ Sleeve Style : Longsleeve : Balloon ====================

            await _optionRepository.InsertAsync(new Option(3313, true, "Sleeve Style", "Fabric Cuff", 1001, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3314, true, "Sleeve Style", "Elastic Cuff", 1002, false, 3007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3315, true, "Sleeve Style", "Clean Finish Hem", 1003, false, 3007), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3339, true, "Sleeve Style", "0.5\"", 1001, false, 3313), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3340, true, "Sleeve Style", "1\"", 1002, false, 3313), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3341, true, "Sleeve Style", "2\"", 1003, false, 3313), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3342, true, "Sleeve Style", "3\"", 1004, false, 3313), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3343, true, "Sleeve Style", "4\"", 1005, false, 3313), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3344, true, "Sleeve Style", "5\"", 1006, false, 3313), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3345, true, "Sleeve Style", "0.5\"", 1001, false, 3314), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3346, true, "Sleeve Style", "1\"", 1002, false, 3314), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3347, true, "Sleeve Style", "2\"", 1003, false, 3314), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3348, true, "Sleeve Style", "3\"", 1004, false, 3314), autoSave: true);


            //============ Sleeve Style : Longsleeve : Flare ====================

            await _optionRepository.InsertAsync(new Option(33106, true, "Sleeve Style", "Clean Finish Hem", 1001, false, 3008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3317, true, "Sleeve Style", "Raw Edge", 1002, false, 3008), autoSave: true);


            //============ Sleeve Style : Longsleeve : Flare (Windbreaker Jacket) ====================

            await _optionRepository.InsertAsync(new Option(3504, true, "Sleeve Style", "Flare", 1004, false, 2904), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3204, true, "Sleeve Style", "Ribbed Cuff", 1001, false, 3504), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3316, true, "Sleeve Style", "Clean Finish Hem", 1001, false, 3504), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3301, true, "Sleeve Style", "0.5\"", 1001, false, 3204), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3302, true, "Sleeve Style", "1\"", 1002, false, 3204), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3303, true, "Sleeve Style", "2\"", 1003, false, 3204), autoSave: true);


            //============ Sleeve Style : Jersey Top ====================

            await _optionRepository.InsertAsync(new Option(3009, true, "Sleeve Style", "Clean Finish", 1001, false, 2901), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3010, true, "Sleeve Style", "Clean Finish", 1001, false, 2902), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3505, true, "Sleeve Style", "Regular", 1001, false, 2903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3506, true, "Sleeve Style", "Oversized", 1002, false, 2903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3507, true, "Sleeve Style", "Balloon", 1003, false, 2903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3508, true, "Sleeve Style", "Flare", 1004, false, 2903), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3509, true, "Sleeve Style", "Clean Finish", 1001, false, 3505), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3510, true, "Sleeve Style", "Clean Finish", 1001, false, 3506), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3511, true, "Sleeve Style", "Clean Finish", 1001, false, 3507), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3512, true, "Sleeve Style", "Clean Finish", 1001, false, 3508), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3513, true, "Sleeve Style", "Regular", 1001, false, 2904), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3514, true, "Sleeve Style", "Oversized", 1002, false, 2904), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3515, true, "Sleeve Style", "Balloon", 1003, false, 2904), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3516, true, "Sleeve Style", "Flare", 1004, false, 2904), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3517, true, "Sleeve Style", "With Thumbhole", 1001, false, 3513), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3518, true, "Sleeve Style", "No Thumbhole", 1002, false, 3513), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3519, true, "Sleeve Style", "Clean Finish", 1001, false, 3517), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3520, true, "Sleeve Style", "Clean Finish", 1001, false, 3518), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3521, true, "Sleeve Style", "Clean Finish", 1001, false, 3514), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3522, true, "Sleeve Style", "Clean Finish", 1001, false, 3515), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3523, true, "Sleeve Style", "Clean Finish", 1001, false, 3516), autoSave: true);


            #endregion


            await _optionRepository.InsertAsync(new Option(3401, true, "Body Length", "Mini", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3402, true, "Body Length", "Midi", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3403, true, "Body Length", "3/4", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3404, true, "Body Length", "Maxi", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3501, true, "Body Length", "Cropped", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3502, true, "Body Length", "Regular", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3503, true, "Body Length", "Long", 1003, false), autoSave: true);


            #region Front Opening

            await _optionRepository.InsertAsync(new Option(3601, true, "Front Opening", "Half Zip", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3602, true, "Front Opening", "Full Zip", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3603, true, "Front Opening", "No Zip", 1003, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3604, true, "Front Opening", "Waterfall", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3605, true, "Front Opening", "Straight", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3606, true, "Front Opening", "Round", 1006, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3701, true, "Front Opening", "6\" Zipper", 1001, false, 3601), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3702, true, "Front Opening", "10\" Zipper", 1002, false, 3601), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3703, true, "Front Opening", "Regular Zipper", 1001, false, 3602), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3704, true, "Front Opening", "Oversized Zipper", 1002, false, 3602), autoSave: true);

            //Sweat Coat
            await _optionRepository.InsertAsync(new Option(3801, true, "Front Opening", "With Belt", 1001, false, 3604), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3802, true, "Front Opening", "No Belt", 1002, false, 3604), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3803, true, "Front Opening", "With Belt", 1001, false, 3605), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3804, true, "Front Opening", "No Belt", 1002, false, 3605), autoSave: true);

            await _optionRepository.InsertAsync(new Option(3805, true, "Front Opening", "With Belt", 1001, false, 3606), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3806, true, "Front Opening", "No Belt", 1002, false, 3606), autoSave: true);

            #endregion


            #region Pocket

            await _optionRepository.InsertAsync(new Option(3901, true, "Pocket", "Front Pocket", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3902, true, "Pocket", "Back Pocket", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(3903, true, "Pocket", "No Pocket", 1003, false), autoSave: true);

            #region Pocket : Front Pocket

            await _optionRepository.InsertAsync(new Option(4001, true, "Pocket", "Side Seam", 1001, false, 3901), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4002, true, "Pocket", "Side Slant", 1002, false, 3901), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4003, true, "Pocket", "Welt", 1003, false, 3901), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4201, true, "Pocket", "With Zip", 1001, false, 4003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4202, true, "Pocket", "No Zip", 1002, false, 4003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4203, true, "Pocket", "No Velcro", 1003, false, 4003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4007, true, "Pocket", "Left Cargo", 1004, false, 3901), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4008, true, "Pocket", "Right Cargo", 1005, false, 3901), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4208, true, "Pocket", "With Zip", 1001, false, 4003), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4209, true, "Pocket", "No Zip", 1002, false, 4003), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4301, true, "Pocket", "With Velcro", 1001, false, 4007), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4302, true, "Pocket", "No Velcro", 1002, false, 4007), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4305, true, "Pocket", "With Velcro", 1001, false, 4008), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4306, true, "Pocket", "No Velcro", 1002, false, 4008), autoSave: true);

            #endregion

            #region Pocket : Back Pokcet

            await _optionRepository.InsertAsync(new Option(4005, true, "Pocket", "Left Patch", 1001, false, 3902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4006, true, "Pocket", "Right Patch", 1002, false, 3902), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4101, true, "Pocket", "Left Welt", 1003, false, 3902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4102, true, "Pocket", "Right Welt", 1004, false, 3902), autoSave: true);

            await _optionRepository.InsertAsync(new Option(43001, true, "Pocket", "With Velcro", 1001, false, 4005), autoSave: true);
            await _optionRepository.InsertAsync(new Option(43002, true, "Pocket", "No Velcro", 1002, false, 4005), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4303, true, "Pocket", "With Velcro", 1001, false, 4006), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4304, true, "Pocket", "No Velcro", 1002, false, 4006), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4204, true, "Pocket", "With Zip", 1001, false, 4101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4205, true, "Pocket", "No Zip", 1002, false, 4101), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4206, true, "Pocket", "With Zip", 1001, false, 4102), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4207, true, "Pocket", "No Zip", 1002, false, 4102), autoSave: true);

            #endregion

            //======= Pocket (Windbreaker/Jersey) ============
            await _optionRepository.InsertAsync(new Option(4011, true, "Pocket", "Side Seam", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4012, true, "Pocket", "Side Slant", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4013, true, "Pocket", "Kangaroo", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4015, true, "Pocket", "No Pocket", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4014, true, "Pocket", "Welt", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4009, true, "Pocket", "Left Patch", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4010, true, "Pocket", "Right Patch", 1002, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(42008, true, "Pocket", "With Zip", 1001, false, 4014), autoSave: true);
            await _optionRepository.InsertAsync(new Option(42009, true, "Pocket", "No Zip", 1002, false, 4014), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4210, true, "Pocket", "With Velcro", 1001, false, 4009), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4211, true, "Pocket", "No Velcro", 1002, false, 4009), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4212, true, "Pocket", "With Velcro", 1001, false, 4010), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4213, true, "Pocket", "No Velcro", 1002, false, 4010), autoSave: true);

            //--------------------------------------------------

            #endregion


            #region Hem

            await _optionRepository.InsertAsync(new Option(4401, true, "Hem", "Straight", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4402, true, "Hem", "Round", 1002, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4509, true, "Hem", "Clean Finish", 1001, false, 4401), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4510, true, "Hem", "Clean Finish", 1001, false, 4402), autoSave: true);

            //=========================================
            await _optionRepository.InsertAsync(new Option(4501, true, "Hem", "Fabric Hem", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4505, true, "Hem", "Ribbed Hem", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4502, true, "Hem", "Elastic Hem", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4503, true, "Hem", "Clean Finish Hem", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4504, true, "Hem", "Tie Cord Hem", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4601, true, "Hem", "1\"", 1001, false, 4501), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4602, true, "Hem", "2\"", 1002, false, 4501), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4603, true, "Hem", "3\"", 1003, false, 4501), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4604, true, "Hem", "4\"", 1004, false, 4501), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4605, true, "Hem", "5\"", 1005, false, 4501), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4609, true, "Hem", "1\"", 1001, false, 4505), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4610, true, "Hem", "2\"", 1002, false, 4505), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4611, true, "Hem", "3\"", 1003, false, 4505), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4612, true, "Hem", "4\"", 1004, false, 4505), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4613, true, "Hem", "5\"", 1005, false, 4505), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4606, true, "Hem", "1\"", 1001, false, 4502), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4607, true, "Hem", "2\"", 1002, false, 4502), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4608, true, "Hem", "3\"", 1003, false, 4502), autoSave: true);
            //-----------------------------------------


            await _optionRepository.InsertAsync(new Option(4506, true, "Hem", "Raw Edge", 1006, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4507, true, "Hem", "Clean Finish", 1001, false), autoSave: true);

            #endregion


            #region Waistband Style

            await _optionRepository.InsertAsync(new Option(4701, true, "Waistband Style", "Fabric Waistband", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4702, true, "Waistband Style", "Elastic Waistband", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4703, true, "Waistband Style", "Activewear Waistband", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4704, true, "Waistband Style", "Ribbed Waistband", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4705, true, "Waistband Style", "Activewear Fabric", 1005, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4801, true, "Waistband Style", "With Drawcord", 1001, false, 4701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4802, true, "Waistband Style", "No Drawcord", 1002, false, 4701), autoSave: true);

            //Sweat Skirt 
            await _optionRepository.InsertAsync(new Option(47004, true, "Waistband Style", "Ribbed Waistband", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(47002, true, "Waistband Style", "Elastic Waistband", 1002, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(47003, true, "Waistband Style", "With Drawcord", 1001, false, 47002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(47005, true, "Waistband Style", "No Drawcord", 1002, false, 47002), autoSave: true);


            //========= Waistband Style : Ribbed Waistband ============

            await _optionRepository.InsertAsync(new Option(4904, true, "Waistband Style", "2\"", 1001, false, 4704), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4905, true, "Waistband Style", "2.5\"", 1002, false, 4704), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4906, true, "Waistband Style", "3\"", 1003, false, 4704), autoSave: true);


            //======= Waistband Style : Elastic Waistband ========

            await _optionRepository.InsertAsync(new Option(4901, true, "Waistband Style", "2\"", 1001, false, 4702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4902, true, "Waistband Style", "2.5\"", 1002, false, 4702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4903, true, "Waistband Style", "3\"", 1003, false, 4702), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4803, true, "Waistband Style", "With Drawcord", 1001, false, 4901), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4804, true, "Waistband Style", "No Drawcord", 1002, false, 4901), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4805, true, "Waistband Style", "With Drawcord", 1001, false, 4902), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4806, true, "Waistband Style", "No Drawcord", 1002, false, 4902), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4807, true, "Waistband Style", "With Drawcord", 1001, false, 4903), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4808, true, "Waistband Style", "No Drawcord", 1002, false, 4903), autoSave: true);

            await _optionRepository.InsertAsync(new Option(4809, true, "Waistband Style", "With Drawcord", 1001, false, 4702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(4810, true, "Waistband Style", "No Drawcord", 1002, false, 4702), autoSave: true);


            #endregion


            await _optionRepository.InsertAsync(new Option(5001, true, "Inside Shorts", "No Shorts", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5002, true, "Inside Shorts", "With Shorts", 1002, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5101, true, "Inside Shorts", "Front Seam", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5102, true, "Inside Shorts", "Length", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5103, true, "Inside Shorts", "Panel", 1003, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5201, true, "Inside Shorts", "Yes", 1001, false, 5101), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5202, true, "Inside Shorts", "No", 1002, false, 5101), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5301, true, "Inside Shorts", "2\" Micro", 1001, false, 5102), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5302, true, "Inside Shorts", "4\" Micro", 1002, false, 5102), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5303, true, "Inside Shorts", "7\" Biker", 1003, false, 5102), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5304, true, "Inside Shorts", "10\" Biker", 1004, false, 5102), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5305, true, "Inside Short Length", "2\" Micro", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5306, true, "Inside Short Length", "4\" Micro", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5307, true, "Inside Short Length", "7\" Biker", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5308, true, "Inside Short Length", "10\" Biker", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5401, true, "Inside Shorts", "L Full Side", 1001, false, 5103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5402, true, "Inside Shorts", "R Full Side", 1002, false, 5103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5403, true, "Inside Shorts", "L Panel", 1003, false, 5103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5404, true, "Inside Shorts", "R Panel", 1004, false, 5103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5405, true, "Inside Shorts", "Regular Side Seam", 1005, false, 5103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5406, true, "Inside Shorts", "No Side Seam", 1006, false, 5103), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5407, true, "Inside Shorts", "Other Design Options", 1007, false, 5103), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5501, true, "Inside Shorts", "With Pocket", 1001, true, 5401), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5502, true, "Inside Shorts", "No Pocket", 1002, true, 5401), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5503, true, "Inside Shorts", "With Pocket", 1001, true, 5402), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5504, true, "Inside Shorts", "No Pocket", 1002, true, 5402), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5601, true, "Inside Shorts", "Front Thigh", 1001, false, 5403), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5602, true, "Inside Shorts", "Back Thigh", 1002, false, 5403), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5603, true, "Inside Shorts", "Front Thigh", 1001, false, 5404), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5604, true, "Inside Shorts", "Back Thigh", 1002, false, 5404), autoSave: true);

            #region Leg Shape

            await _optionRepository.InsertAsync(new Option(5701, true, "Leg Shape", "Regular Leg", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5702, true, "Leg Shape", "Flare Leg", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5703, true, "Leg Shape", "Wide Leg", 1003, false), autoSave: true);

            //===== Leg Shape (Jershey Shorts) ======

            await _optionRepository.InsertAsync(new Option(5819, true, "Leg Shape", "Clean Finish Hem", 1001, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5820, true, "Leg Shape", "Raw Edge", 1002, false, 5701), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5821, true, "Leg Shape", "Clean Finish Hem", 1001, false, 5703), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5822, true, "Leg Shape", "Raw Edge", 1001, false, 5703), autoSave: true);


            #region Leg Shape : Regular Leg

            await _optionRepository.InsertAsync(new Option(5801, true, "Leg Shape", "Fabric Cuff", 1001, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5802, true, "Leg Shape", "Ribbed Cuff", 1002, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5803, true, "Leg Shape", "Elastic Cuff", 1003, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5804, true, "Leg Shape", "Clean Finish Hem", 1004, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5805, true, "Leg Shape", "Tie Cord Hem", 1005, false, 5701), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5901, true, "Leg Shape", "1\"", 1001, false, 5801), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5902, true, "Leg Shape", "2\"", 1002, false, 5801), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5903, true, "Leg Shape", "2.5\"", 1003, false, 5801), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5904, true, "Leg Shape", "3\"", 1004, false, 5801), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5905, true, "Leg Shape", "1\"", 1001, false, 5802), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5906, true, "Leg Shape", "2\"", 1002, false, 5802), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5907, true, "Leg Shape", "2.5\"", 1003, false, 5802), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5908, true, "Leg Shape", "3\"", 1004, false, 5802), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5909, true, "Leg Shape", "1\"", 1001, false, 5803), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5910, true, "Leg Shape", "2\"", 1002, false, 5803), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5911, true, "Leg Shape", "2.5\"", 1003, false, 5803), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5912, true, "Leg Shape", "3\"", 1004, false, 5803), autoSave: true);

            #endregion


            await _optionRepository.InsertAsync(new Option(5807, true, "Leg Shape", "Clean Finish Hem", 1001, false, 5702), autoSave: true);

            //=============== Regular Leg (Jersey Jogger) ==================

            await _optionRepository.InsertAsync(new Option(5809, true, "Leg Shape", "Fabric Cuff", 1001, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5810, true, "Leg Shape", "Ribbed Cuff", 1002, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5811, true, "Leg Shape", "Elastic Cuff", 1003, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5812, true, "Leg Shape", "Clean Finish Hem", 1004, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5813, true, "Leg Shape", "Tie Cord Hem", 1005, false, 5701), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5814, true, "Leg Shape", "Raw Edge", 1006, false, 5701), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5913, true, "Leg Shape", "1\"", 1001, false, 5809), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5914, true, "Leg Shape", "2\"", 1002, false, 5809), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5915, true, "Leg Shape", "2.5\"", 1003, false, 5809), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5916, true, "Leg Shape", "3\"", 1004, false, 5809), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5917, true, "Leg Shape", "1\"", 1001, false, 5810), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5918, true, "Leg Shape", "2\"", 1002, false, 5810), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5919, true, "Leg Shape", "2.5\"", 1003, false, 5810), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5920, true, "Leg Shape", "3\"", 1004, false, 5810), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5921, true, "Leg Shape", "1\"", 1001, false, 5811), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5922, true, "Leg Shape", "2\"", 1002, false, 5811), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5923, true, "Leg Shape", "2.5\"", 1003, false, 5811), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5924, true, "Leg Shape", "3\"", 1004, false, 5811), autoSave: true);


            await _optionRepository.InsertAsync(new Option(5815, true, "Leg Shape", "Clean Finish Hem", 1001, false, 5702), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5816, true, "Leg Shape", "Raw Edge", 1002, false, 5702), autoSave: true);

            await _optionRepository.InsertAsync(new Option(5817, true, "Leg Shape", "Clean Finish Hem", 1001, false, 5703), autoSave: true);
            await _optionRepository.InsertAsync(new Option(5818, true, "Leg Shape", "Raw Edge", 1002, false, 5703), autoSave: true);

            #endregion


            #region Inside Short Panel

            await _optionRepository.InsertAsync(new Option(6001, true, "Inside Short Panel", "L Full Side", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6002, true, "Inside Short Panel", "R Full Side", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6003, true, "Inside Short Panel", "Regular Side Seam", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6004, true, "Inside Short Panel", "No Side Seam", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6005, true, "Inside Short Panel", "Other Design Options", 1005, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(6101, true, "Inside Short Panel", "With Pocket", 1001, false, 6001), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6102, true, "Inside Short Panel", "No Pocket", 1002, false, 6001), autoSave: true);

            await _optionRepository.InsertAsync(new Option(6103, true, "Inside Short Panel", "With Pocket", 1001, false, 6002), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6104, true, "Inside Short Panel", "No Pocket", 1002, false, 6002), autoSave: true);

            #endregion


            await _optionRepository.InsertAsync(new Option(6201, true, "Outside Shorts", "Windbreaker Material", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6202, true, "Outside Shorts", "Mesh Material", 1002, true), autoSave: true);

            await _optionRepository.InsertAsync(new Option(6301, true, "Neckline Style", "Round", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6302, true, "Neckline Style", "Square", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6303, true, "Neckline Style", "V-Neck", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6304, true, "Neckline Style", "Halter Neck", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6305, true, "Neckline Style", "Straight Across", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6306, true, "Neckline Style", "Sweetheart", 1006, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6307, true, "Neckline Style", "Boat Neck", 1007, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6308, true, "Neckline Style", "Asymmetric", 1008, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(6401, true, "Strap", "0.4\" Strap", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6402, true, "Strap", "0.8\" Strap", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6403, true, "Strap", "1\" Strap", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6404, true, "Strap", "1.5\" Strap", 1004, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6405, true, "Strap", "2\" Strap", 1005, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6406, true, "Strap", "No", 1006, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(6501, true, "Inside Short Panel", "2\" Micro", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6502, true, "Inside Short Panel", "4\" Short", 1002, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6503, true, "Inside Short Panel", "7\" Biker", 1003, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6504, true, "Inside Short Panel", "10\" Biker", 1004, false), autoSave: true);

            await _optionRepository.InsertAsync(new Option(6505, true, "Outside Branding", "Yes", 1001, false), autoSave: true);
            await _optionRepository.InsertAsync(new Option(6506, true, "Outside Branding", "No", 1001, false), autoSave: true);
        }
    }
}