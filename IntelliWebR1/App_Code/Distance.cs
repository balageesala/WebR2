using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using IntellidateR1;

namespace IntelliWebR1
{
    public static class Distance
    {
        // Handy structure for Long/Lat information
        public struct Coords
        {
            public double Longitude;
            public double Latitude;
        }

        // Unit calculations
        public enum Units
        {
            Miles,
            Kilometres
        }

        // Will return a null if the Google API is unable to find either post code, or the country constraint fails
        public static double? BetweenTwoPostCodes(string postcodeA, string postcodeB, Units units)
        {
            bool IsCodeAApi = true;
            bool IsCodeBApi = true;
            zipcodes _codeADetails = new zipcodes().GetZipcodeDetails(postcodeA);
            zipcodes _codeBDetails = new zipcodes().GetZipcodeDetails(postcodeB);
            if (_codeADetails != null)
            {
                if (_codeADetails.loc != null)
                {
                    IsCodeAApi = false;
                }
            }
            if (_codeBDetails != null)
            {
                if (_codeBDetails.loc != null)
                {
                    IsCodeBApi = false;
                }
            }


            var ll1 = PostCodeToLongLat(postcodeA, IsCodeAApi);
            if (!ll1.HasValue) return null;
            var ll2 = PostCodeToLongLat(postcodeB, IsCodeBApi);
            if (!ll2.HasValue) return null;
            return ll1.Value.DistanceTo(ll2.Value, units);
        }

        // load distance in miles
        public static double? BetweenTwoPostCodesInMiles(string postcodeA, string postcodeB)
        {
           
            return BetweenTwoPostCodes(postcodeA, postcodeB, Units.Miles);
        }

        // load distance in kms
        public static double? BetweenTwoPostCodesInKms(string postcodeA, string postcodeB)
        {
            return BetweenTwoPostCodes(postcodeA, postcodeB, Units.Kilometres);
        }


        // Uses the Google API to resolve a post code (within the specified country)
        public static Coords? PostCodeToLongLatOld(string postcode , bool isUseApi)
        {
            if (isUseApi)
            {
                // Download the XML response from Google
                var client = new WebClient();
                var encodedPostCode = HttpUtility.UrlEncode(postcode);
                var url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?country=US&&address=" + encodedPostCode);
                var JsonString = client.DownloadString(url);
                RootObject _ResObject = JsonConvert.DeserializeObject<RootObject>(JsonString);
                double coordslong;
                double coordslatt;
                if (_ResObject.status.ToUpper() == "OK")
                {
                    //add zip code details in cache database

                    coordslong = _ResObject.results[0].geometry.location.lng;
                    coordslatt = _ResObject.results[0].geometry.location.lat;
                    zipcodes _codeDetails = new zipcodes().GetZipcodeDetails(postcode);
                    decimal[] locs = new decimal[] { Convert.ToDecimal(coordslong), Convert.ToDecimal(coordslatt) };
                   // new zipcodes().AddZipCodes(_ResObject.results[0].formatted_address, postcode, locs, 0, _ResObject.results[0].address_components[1].long_name);
                    return new Coords
                    {
                        Longitude = coordslong,
                        Latitude = coordslatt
                    };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                zipcodes _codeDetails = new zipcodes().GetZipcodeDetails(postcode);
                if (_codeDetails != null)
                {

                    double _lag = Convert.ToDouble(_codeDetails.loc[0]);                    
                    double _latt= Convert.ToDouble(_codeDetails.loc[1]);

                    return new Coords
                    {
                        Longitude = _lag,
                        Latitude = _latt
                    };
                }
                else
                {
                    return null;
                }
            }
            
        }



        public static Coords? PostCodeToLongLat(string postcode, bool isUseApi)
        {
            try
            {
                zipcodes _codeDetails = new zipcodes().GetZipcodeDetails(postcode);
                if (_codeDetails != null)
                {

                    double _lag = Convert.ToDouble(_codeDetails.loc[0]);
                    double _latt = Convert.ToDouble(_codeDetails.loc[1]);

                    return new Coords
                    {
                        Longitude = _lag,
                        Latitude = _latt
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;             
            }
               
        }

        public static string GetAddressFromZipCode(string postcode)
        {
            try
            {
                zipcodes _zipCodeDetails = new zipcodes().GetZipcodeDetails(postcode);
                if (_zipCodeDetails != null)
                {
                    return _zipCodeDetails.city;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public static string GetAddressFromZipCodeOld(string postcode)
        {
            try
            {
                zipcodes _zipCodeDetails = new zipcodes().GetZipcodeDetails(postcode);
                if (_zipCodeDetails != null)
                {
                    return _zipCodeDetails.city;
                }
                else
                {
                    var client = new WebClient();
                    var encodedPostCode = HttpUtility.UrlEncode(postcode);
                    var url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?country=US&&address=" + encodedPostCode);
                    var JsonString = client.DownloadString(url);
                    RootObject _ResObject = JsonConvert.DeserializeObject<RootObject>(JsonString);
                    double coordslong;
                    double coordslatt;
                    if (_ResObject.status.ToUpper() == "OK")
                    {
                        //add zip code details in cache database

                        coordslong = _ResObject.results[0].geometry.location.lng;
                        coordslatt = _ResObject.results[0].geometry.location.lat;
                        zipcodes _codeDetails = new zipcodes().GetZipcodeDetails(postcode);
                        decimal[] locs = new decimal[] { Convert.ToDecimal(coordslong), Convert.ToDecimal(coordslatt) };
                       // new zipcodes().AddZipCodes(_ResObject.results[0].formatted_address, postcode, locs, 0, _ResObject.results[0].address_components[3].long_name);
                        return _ResObject.results[0].formatted_address;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }



        public static double DistanceTo(this Coords from, Coords to, Units units)
        {
            // Haversine Formula...
            var dLat1InRad = from.Latitude * (Math.PI / 180.0);
            var dLong1InRad = from.Longitude * (Math.PI / 180.0);
            var dLat2InRad = to.Latitude * (Math.PI / 180.0);
            var dLong2InRad = to.Longitude * (Math.PI / 180.0);

            var dLongitude = dLong2InRad - dLong1InRad;
            var dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            var a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                    Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                    Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            var c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Unit of measurement
            var radius = 6371;
            if (units == Units.Miles) radius = 3959;

            return radius * c;
        }
    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast2 northeast { get; set; }
        public Southwest2 southwest { get; set; }
    }

    public class Geometry
    {
        public Bounds bounds { get; set; }
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public List<string> postcode_localities { get; set; }
        public List<string> types { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

}