using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace ExtendsApi.Models
{
    public class IntFilter
    {
        public int?[] Include { get; set; }
        public int?[] Exclude { get; set; }

        private bool CheckIncluds(int? element)
        {
            if (element == null)
                return false;

            if (Include == null || Include.Length <= 0)
                return true;
            return Include.Any(x => x == element);
        }

        private bool CheckExcluds(int? element)
        {
            if (element == null)
                return false;

            if (Exclude == null || Exclude.Length <= 0)
                return true;
            return !Exclude.Any(x => x == element);
        }

        public bool CheckFilter(int? element)
        {
            return (CheckIncluds(element) && CheckExcluds(element));
        }
    }

    public class StringFilter
    {
        public string Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FilterType FilterType { get; set; }

        public bool CheckFilter(string element)
        {
            if (element == null)
                return false;

            return FilterType switch
            {
                FilterType.Contains => element.ToLower().Contains(Value.ToLower()),
                FilterType.Equals => element.ToLower().Equals(Value.ToLower()),
                FilterType.StartsWith => element.ToLower().StartsWith(Value.ToLower()),
                FilterType.EndsWith => element.ToLower().EndsWith(Value.ToLower()),
                _ => true,
            };
        }
    }

    public enum FilterType
    {
        Contains,
        Equals,
        StartsWith,
        EndsWith
    }

    public class DateTimeNullableFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool CheckFilter(DateTime? element)
        {
            if (element == null)
                return true;

            if (StartDate == null && EndDate == null)
                return true;

            if (StartDate != null)
            {
                if (EndDate != null)
                    return (element >= StartDate && element <= EndDate);

                return element >= StartDate;
            }

            if (EndDate != null)
                return element <= EndDate;


            return true;
        }
    }

    public class DecimalFilter
    {
        public decimal[] Include { get; set; }
        public decimal[] Exclude { get; set; }

        private bool CheckIncluds(decimal? element)
        {
            if (element == null)
                return false;

            if (Include == null || Include.Length <= 0)
                return true;
            return Include.Any(x => x == element);
        }

        private bool CheckExcluds(decimal? element)
        {
            if (element == null)
                return false;

            if (Exclude == null || Exclude.Length <= 0)
                return true;
            return Exclude.Any(x => x == element);
        }

        public bool CheckFilter(decimal? element)
        {
            return (CheckIncluds(element) && CheckExcluds(element));
        }
    }

    public class GuidFilter
    {
        public Guid?[] Include { get; set; }
        public Guid?[] Exclude { get; set; }

        private bool CheckIncluds(Guid? element)
        {
            if (element == null)
                return false;

            if (Include == null || Include.Length <= 0)
                return true;
            return Include.Any(x => x == element);
        }

        private bool CheckExcluds(Guid? element)
        {
            if (element == null)
                return false;

            if (Exclude == null || Exclude.Length <= 0)
                return true;
            return !Exclude.Any(x => x == element);
        }

        public bool CheckFilter(Guid? element)
        {
            return (CheckIncluds(element) && CheckExcluds(element));
        }
    }

    public class DateTimeOffsetNullableFilter
    {
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public bool CheckFilter(DateTimeOffset? element)
        {
            if (element == null)
                return true;

            if (StartDate == null && EndDate == null)
                return true;

            if (StartDate != null)
            {
                if (EndDate != null)
                    return (element >= StartDate && element <= EndDate);

                return element >= StartDate;
            }

            if (EndDate != null)
                return element <= EndDate;


            return true;
        }
    }
    
    public class LongFilter
    {
        public long[] Include { get; set; }
        public long[] Exclude { get; set; }

        public bool CheckFilter(long? element)
        {
            return CheckIncluds(element) && CheckExcluds(element);
        }

        private bool CheckIncluds(long? element)
        {
            if (element == null)
            {
                return false;
            }

            if (Include == null || Include.Length <= 0)
            {
                return true;
            }

            return Include.Any(x => x == element);
        }

        private bool CheckExcluds(long? element)
        {
            if (element == null)
            {
                return false;
            }

            if (Exclude == null || Exclude.Length <= 0)
            {
                return true;
            }

            return Exclude.Any(x => x == element);
        }
    }
}
