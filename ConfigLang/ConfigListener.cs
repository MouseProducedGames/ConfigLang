using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace ConfigLang
{
    public class ConfigListener : ConfigLangParserBaseListener
    {
        private readonly Dictionary<string, ConfigValue> lookup =
            new Dictionary<string, ConfigValue>();

        public Dictionary<string, ConfigValue> Lookup
        {
            get
            {
                return lookup;
            }
        }

        public override void ExitStat([NotNull] ConfigLangParser.StatContext context)
        {
            if (context.@float != null)
            {
                double value;
                if (double.TryParse(context.@float.Text, out value) == true)
                {
                    Lookup[context.name.Text] = new ConfigFloat(value);
                }
                else
                {
                    context.AddErrorNode(context.@float);
                }
            }
            else if (context.@int != null)
            {
                long value;
                if (long.TryParse(context.@int.Text, out value) == true)
                {
                    Lookup[context.name.Text] = new ConfigInt(value);
                }
                else
                {
                    context.AddErrorNode(context.@int);
                }
            }
            else if (context.id != null)
            {
                switch (context.id.Text.ToUpper())
                {
                    case "TRUE":
                        Lookup[context.name.Text] = new ConfigBool(true);
                        break;
                    case "FALSE":
                        Lookup[context.name.Text] = new ConfigBool(false);
                        break;
                    default:
                        Lookup[context.name.Text] =
                            new ConfigString(context.id.Text);
                        break;
                }
            }
            else
            {
                context.AddErrorNode(context.start);
            }
        }
    }
}
