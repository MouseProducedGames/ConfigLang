using System;

namespace ConfigLang
{
    public abstract class ConfigValue : IEquatable<ConfigValue>
    {
        public abstract ConfigValueType ConfigValueType { get; }

        public abstract Type ValueType { get; }

        public abstract bool Equals(ConfigValue other);

        public override bool Equals(object obj)
        {
            return
                obj is ConfigValue &&
                Equals((ConfigValue)obj);
        }

        public abstract override int GetHashCode();

        public abstract override string ToString();

        public static bool operator ==(ConfigValue left, ConfigValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConfigValue left, ConfigValue right)
        {
            return (left == right) == false;
        }
    }

    public abstract class ConfigValue<T> : ConfigValue
    {
        private T value;

        public T Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public ConfigValue(T value)
        {
            this.value = value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(ConfigValue other)
        {
            return
                other.ConfigValueType == ConfigValueType &&
                Value.Equals(((ConfigValue<T>)other).Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class ConfigBool : ConfigValue<bool>
    {
        public ConfigBool(bool value) : base(value)
        {
        }

        public override ConfigValueType ConfigValueType
        {
            get
            {
                return ConfigValueType.Boolean;
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(bool);
            }
        }
    }

    public class ConfigFloat : ConfigValue<double>
    {
        public ConfigFloat(double value) : base(value)
        {
        }

        public override ConfigValueType ConfigValueType
        {
            get
            {
                return ConfigValueType.Float;
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(bool);
            }
        }
    }

    public class ConfigInt : ConfigValue<long>
    {
        public ConfigInt(long value) : base(value)
        {
        }

        public override ConfigValueType ConfigValueType
        {
            get
            {
                return ConfigValueType.Int;
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(long);
            }
        }
    }

    public class ConfigString : ConfigValue<string>
    {
        public ConfigString(string value) : base(value)
        {
        }

        public override ConfigValueType ConfigValueType
        {
            get
            {
                return ConfigValueType.String;
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class ConfigNull : ConfigValue
    {
        public override ConfigValueType ConfigValueType
        {
            get
            {
                return ConfigValueType.NULL;
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(object);
            }
        }

        public override bool Equals(ConfigValue other)
        {
            return other is ConfigNull;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return "NULL";
        }
    }
}