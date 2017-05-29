using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLang
{
    public class ConfigReader
    {
        private readonly Dictionary<string, ConfigValue> lookup =
            new Dictionary<string, ConfigValue>();

        private static readonly ConfigNull NULL = new ConfigNull();

        public ConfigReader(string text)
        {
            var stream = new AntlrInputStream(text);
            var lexer = new ConfigLangLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ConfigLangParser(tokens);

            var context = parser.compileUnit();

            var treeWalker = new ParseTreeWalker();
            var listener = new ConfigListener();
            treeWalker.Walk(listener, context);

            lookup = listener.Lookup;
        }

        public bool Contains(string name)
        {
            return lookup.ContainsKey(name);
        }

        public bool Contains(string name, ConfigValueType configValueType)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.NULL:
                    return false;
                default:
                    return configValue.ConfigValueType == configValueType;
            }
        }

        public bool Contains(string name, Type valueType)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.NULL:
                    return false;
                default:
                    return configValue.ValueType == valueType;
            }
        }

        /// <summary>
        /// Returns ConfigNull if value does not exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ConfigValue ReadConfigValue(string name)
        {
            ConfigValue output;
            if (lookup.TryGetValue(name, out output) == true)
            {
                return output;
            }
            else
            {
                return NULL;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a float.</exception>
        public ConfigValue<bool> ReadConfigBool(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    return ((ConfigValue<bool>)configValue);
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a float.</exception>
        public ConfigValue<double> ReadConfigDouble(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Float:
                    return ((ConfigValue<double>)configValue);
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a float.</exception>
        public ConfigValue<long> ReadConfigLong(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Int:
                    return ((ConfigValue<long>)configValue);
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a float.</exception>
        public ConfigValue<string> ReadConfigString(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Float:
                    return ((ConfigValue<string>)configValue);
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        public ConfigValueType ReadConfigValueType(string name)
        {
            return ReadConfigValue(name).ConfigValueType;
        }

        public bool TryReadConfigBool(string name, out ConfigValue<bool> output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<bool>)configValue);
                    return true;
                default:
                    output = null;
                    return false;
            }
        }

        public bool TryReadConfigDouble(string name, out ConfigValue<double> output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<double>)configValue);
                    return true;
                default:
                    output = null;
                    return false;
            }
        }

        public bool TryReadConfigLong(string name, out ConfigValue<long> output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<long>)configValue);
                    return true;
                default:
                    output = null;
                    return false;
            }
        }

        public bool TryReadConfigSring(string name, out ConfigValue<string> output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<string>)configValue);
                    return true;
                default:
                    output = null;
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="output">If the name is not found, output will be ConfigValueType.NULL.</param>
        /// <returns></returns>
        public bool TryReadConfigValueType(string name, out ConfigValueType output)
        {
            ConfigValue temp;
            if (lookup.TryGetValue(name, out temp) == true)
            {
                output = temp.ConfigValueType;
                return true;
            }
            else
            {
                output = ConfigValueType.NULL;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a bool.</exception>
        public bool ReadBool(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    return ((ConfigValue<bool>)configValue).Value;
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a float.</exception>
        public double ReadDouble(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Float:
                    return ((ConfigValue<double>)configValue).Value;
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not an int.</exception>
        public long ReadLong(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Int:
                    return ((ConfigValue<long>)configValue).Value;
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If config value does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If config value is not a string.</exception>
        public string ReadString(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.String:
                    return ((ConfigValue<string>)configValue).Value;
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    throw new ArgumentOutOfRangeException(name);
            }
        }

        public Type ReadType(string name)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.NULL:
                    throw new ArgumentNullException(name);
                default:
                    return configValue.ValueType;
            }
        }

        public bool TryReadBool(string name, out bool output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<bool>)configValue).Value;
                    return true;
                default:
                    output = false;
                    return false;
            }
        }

        public bool TryReadDouble(string name, out double output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<double>)configValue).Value;
                    return true;
                default:
                    output = 0;
                    return false;
            }
        }

        public bool TryReadLong(string name, out long output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<long>)configValue).Value;
                    return true;
                default:
                    output = 0;
                    return false;
            }
        }

        public bool TryReadString(string name, out string output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.Boolean:
                    output = ((ConfigValue<string>)configValue).Value;
                    return true;
                default:
                    output = null;
                    return false;
            }
        }

        public bool TryReadType(string name, out Type output)
        {
            var configValue = ReadConfigValue(name);
            switch (configValue.ConfigValueType)
            {
                case ConfigValueType.NULL:
                    output = null;
                    return false;
                default:
                    output = configValue.ValueType;
                    return true;
            }
        }
    }
}
