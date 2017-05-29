using System;

namespace ConfigLang
{
    public abstract class ConfigValue
    {
        public abstract ConfigValueType ConfigValueType { get; }

        public abstract Type ValueType { get; }
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
    }
}