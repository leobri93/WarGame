using System.Collections.Generic;
using WarGame.Models;

namespace WarGame.Helper
{
    public static class Westeros
    {

        public static List<RegionViewModel> Map()
        {
            var regions = new List<RegionViewModel>();
            var kingdom = Kingdom.Instance;
            var region = Region.Instance(kingdom);

            AddFrontiers(region);
            AddRegions(regions, region);
           
            return regions;
        }

        private static void AddFrontiers(Region region)
        {
            region.Sanspear.Frontiers(new List<RegionViewModel>
                    { region.Sandstone });

            region.Sandstone.Frontiers(new List<RegionViewModel> 
                    { region.Sanspear, region.RedMountains });

            region.RedMountains.Frontiers(new List<RegionViewModel>
                    { region.Sandstone, region.Highgarden, region.Oldtown, region.DornishNarchis });

            region.Oldtown.Frontiers(new List<RegionViewModel>
                    { region.RedMountains, region.OldNak, region.Highgarden });

            region.Highgarden.Frontiers(new List<RegionViewModel>
                    { region.RedMountains, region.OldNak, region.Oldtown,
                     region.BlackWaterRush, region.DornishNarchis });

            region.BlackWaterRush.Frontiers(new List<RegionViewModel>
                    { region.Highgarden, region.OldNak, region.SilberHill, region.DornishNarchis });

            region.OldNak.Frontiers(new List<RegionViewModel>
                    { region.Oldtown, region.Highgarden, region.BlackWaterRush, region.SilberHill,
                     region.Cornfield, region.Lannisvort });

            region.SilberHill.Frontiers(new List<RegionViewModel>
                    { region.BlackWaterRush, region.OldNak, region.DornishNarchis, region.Kingswood,
                     region.KingsLanding, region.StoneScut, region.CasterlyRock, region.Lannisvort });

            region.DornishNarchis.Frontiers(new List<RegionViewModel>
                    { region.RedMountains, region.Highgarden, region.BlackWaterRush, region.SilberHill,
                     region.Kingswood, region.StormsEnd, region.Rainwood });

            region.Rainwood.Frontiers(new List<RegionViewModel>
                    { region.DornishNarchis, region.Tarth, region.StormsEnd });

            region.StormsEnd.Frontiers(new List<RegionViewModel>
                    { region.DornishNarchis, region.Tarth, region.Rainwood, region.Kingswood });

            region.Tarth.Frontiers(new List<RegionViewModel>
                    { region.StormsEnd, region.Rainwood });

            region.Kingswood.Frontiers(new List<RegionViewModel>
                   { region.DornishNarchis, region.StormsEnd, region.KingsLanding, region.SilberHill });

            region.KingsLanding.Frontiers(new List<RegionViewModel>
                   { region.Kingswood, region.StoneScut, region.Harrenhal, region.SilberHill,
                     region.Riberrun, region.CrackclawPoint});

            region.CrackclawPoint.Frontiers(new List<RegionViewModel>
                   { region.KingsLanding, region.Harrenhal, region.TheTwins, region.SaltPans });

            region.Cornfield.Frontiers(new List<RegionViewModel>
                   { region.OldNak, region.Lannisvort });

            region.Lannisvort.Frontiers(new List<RegionViewModel>
                   { region.Cornfield, region.CasterlyRock, region.OldNak, region.SilberHill });

            region.CasterlyRock.Frontiers(new List<RegionViewModel>
                   { region.Lannisvort, region.TheCrag, region.GoldenTooth, region.SilberHill,
                     region.StoneScut });

            region.GoldenTooth.Frontiers(new List<RegionViewModel>
                   { region.CasterlyRock, region.TheCrag, region.Riberrun, region.StoneScut });

            region.StoneScut.Frontiers(new List<RegionViewModel>
                   { region.SilberHill, region.CasterlyRock, region.GoldenTooth, region.Riberrun,
                     region.KingsLanding });

            region.TheCrag.Frontiers(new List<RegionViewModel>
                   { region.CasterlyRock, region.GoldenTooth, region.Riberrun,
                     region.Pyke });

            region.Riberrun.Frontiers(new List<RegionViewModel>
                   { region.TheCrag, region.GoldenTooth, region.StoneScut, region.TheTwins,
                     region.Harrenhal, region.KingsLanding });

            region.Harrenhal.Frontiers(new List<RegionViewModel>
                   { region.Riberrun, region.CrackclawPoint, region.TheTwins, region.KingsLanding });

            region.TheTwins.Frontiers(new List<RegionViewModel>
                    { region.Riberrun, region.Harrenhal, region.TheNeck, region.WestBale,
                      region.TheMountainsOfTheMoon, region.SaltPans, region.CrackclawPoint, region.Harlaw});

            region.Harlaw.Frontiers(new List<RegionViewModel>
                    { region.Pyke, region.TheTwins, region.CapeKrake, region.TheNeck });

            region.Pyke.Frontiers(new List<RegionViewModel>
                    { region.TheCrag, region.Harlaw });

            region.WestBale.Frontiers(new List<RegionViewModel>
                    { region.TheFingers, region.TheNeck, region.TheTwins, region.TheMountainsOfTheMoon });

            region.TheFingers.Frontiers(new List<RegionViewModel>
                    { region.WestBale, region.TheEyrie, region.TheMountainsOfTheMoon });

            region.TheMountainsOfTheMoon.Frontiers(new List<RegionViewModel>
                    { region.TheTwins, region.WestBale, region.TheFingers, region.TheEyrie, region.SaltPans});

            region.TheEyrie.Frontiers(new List<RegionViewModel>
                    { region.TheMountainsOfTheMoon, region.TheFingers, region.SaltPans});

            region.SaltPans.Frontiers(new List<RegionViewModel>
                    { region.TheMountainsOfTheMoon, region.TheEyrie, region.TheTwins, region.Gulltown,
                      region.CrackclawPoint });

            region.CapeKrake.Frontiers(new List<RegionViewModel>
                   { region.Harlaw, region.TheNeck });

            region.TheNeck.Frontiers(new List<RegionViewModel>
                   { region.TheTwins, region.CapeKrake, region.Barrowlands, region.WhiteHabor, region.Harlaw });

            region.WhiteHabor.Frontiers(new List<RegionViewModel>
                  { region.TheNeck, region.Barrowlands, region.Winterfell, region.WidowsWatch });

            region.StoneShore.Frontiers(new List<RegionViewModel>
                  { region.Barrowlands, region.TheWolfwoods, region.BearIsland });

            region.TheWolfwoods.Frontiers(new List<RegionViewModel>
                  { region.StoneShore, region.Barrowlands, region.BearIsland, region.Winterfell });

            region.BearIsland.Frontiers(new List<RegionViewModel>
                 { region.StoneShore, region.TheWolfwoods, region.Winterfell });

            region.Winterfell.Frontiers(new List<RegionViewModel>
                 { region.Barrowlands, region.TheWolfwoods, region.WhiteHabor, region.WidowsWatch,
                   region.TheGreyCliffs, region.BearIsland });

            region.Barrowlands.Frontiers(new List<RegionViewModel>
                 { region.StoneShore, region.TheWolfwoods, region.WhiteHabor, region.TheNeck, region.Winterfell });

            region.WidowsWatch.Frontiers(new List<RegionViewModel>
                { region.WhiteHabor, region.Winterfell });

            region.TheGreyCliffs.Frontiers(new List<RegionViewModel>
                { region.Winterfell });
            region.Harlaw.Frontiers(new List<RegionViewModel>
                    { region.Pyke, region.TheTwins, region.CapeKrake, region.TheNeck });
            region.Gulltown.Frontiers(new List<RegionViewModel>
                    { region.SaltPans });
        }

        private static void AddRegions(List<RegionViewModel> regions, Region region) 
        {
            regions.Add(region.BearIsland);
            regions.Add(region.TheGreyCliffs);
            regions.Add(region.Winterfell);
            regions.Add(region.TheWolfwoods);
            regions.Add(region.WidowsWatch);
            regions.Add(region.WhiteHabor);
            regions.Add(region.WestBale);
            regions.Add(region.Barrowlands);
            regions.Add(region.StoneShore);
            regions.Add(region.CapeKrake);
            regions.Add(region.TheNeck);
            regions.Add(region.TheFingers);
            regions.Add(region.TheEyrie);
            regions.Add(region.TheMountainsOfTheMoon);
            regions.Add(region.Gulltown);
            regions.Add(region.SaltPans);
            regions.Add(region.TheTwins);
            regions.Add(region.Harrenhal);
            regions.Add(region.Riberrun);
            regions.Add(region.TheCrag);
            regions.Add(region.Pyke);
            regions.Add(region.Harlaw);
            regions.Add(region.CrackclawPoint);
            regions.Add(region.KingsLanding);
            regions.Add(region.Kingswood);
            regions.Add(region.Tarth);
            regions.Add(region.StormsEnd);
            regions.Add(region.Rainwood);
            regions.Add(region.DornishNarchis);
            regions.Add(region.StoneScut);
            regions.Add(region.GoldenTooth);
            regions.Add(region.CasterlyRock);
            regions.Add(region.Lannisvort);
            regions.Add(region.Cornfield);
            regions.Add(region.SilberHill);
            regions.Add(region.BlackWaterRush);
            regions.Add(region.OldNak);
            regions.Add(region.Highgarden);
            regions.Add(region.Oldtown);
            regions.Add(region.RedMountains);
            regions.Add(region.Sandstone);
            regions.Add(region.Sanspear);
        }
    }
}