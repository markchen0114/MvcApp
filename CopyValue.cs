/// <summary>DataRow to Object</summary>
        /// <param name="ao_Row">Source DataRow</param>
        /// <param name="ao_Target">Target object</param>
        /// <param name="aa_ExclusiveList">Property name exclusive list</param>
        public static void CopyValue(DataRow ao_Row, object ao_Target, List<string> aa_ExclusiveList = null)
        {
            DateTime dtTmp; //TryParse
            TimeSpan tsTmp; //TryParse
            string strTmp; //TryPasre

            if (ao_Row == null || ao_Target == null)
            {
                return;
            }

            //Process source items
            foreach (DataColumn lo_SourceCol in ao_Row.Table.Columns)
            {
                #region validation
                //Property name in the list of exclusive items, do not copy value
                if (aa_ExclusiveList != null && aa_ExclusiveList.Contains(lo_SourceCol.ColumnName))
                {
                    continue;
                }

                var lo_TargetProperty = ao_Target.GetType().GetProperty(lo_SourceCol.ColumnName);
                //Target property doesn't exist or cannot be wrote, do not copy value
                if (lo_TargetProperty == null || !lo_TargetProperty.CanWrite)
                {
                    continue;
                }

                var lo_TargetOriValue = lo_TargetProperty.GetValue(ao_Target, null);
                //Source value = Target value => no need to copy value
                if (ao_Row[lo_SourceCol.ColumnName] != null && lo_TargetOriValue != null && ao_Row[lo_SourceCol.ColumnName].ToString() == lo_TargetOriValue.ToString())
                {
                    continue;
                }
                #endregion validation

                //Copy value when source value is null
                if (Convert.IsDBNull(ao_Row[lo_SourceCol.ColumnName]))
                {
                    if (Nullable.GetUnderlyingType(lo_TargetProperty.PropertyType) == null)
                    {
                        lo_TargetProperty.SetValue(ao_Target, null, null);
                    }
                    else
                    {
                        lo_TargetProperty.SetValue(ao_Target, Activator.CreateInstance(lo_TargetProperty.GetType()), null);
                    }
                    continue;
                }

                #region Special transfer rule
                //Target type is DateTime or DateTime?, Source type is string
                if ((lo_TargetProperty.PropertyType == typeof(DateTime) || lo_TargetProperty.PropertyType == typeof(DateTime?))
                    && lo_SourceCol.DataType == typeof(string))
                {
                    strTmp = ao_Row[lo_SourceCol.ColumnName].ToString();
                    if (DateTime.TryParse(strTmp, out dtTmp))
                    {
                        lo_TargetProperty.SetValue(ao_Target, dtTmp, null);
                    }
                    continue;
                }

                //Target type is string, Source type is DateTime or DateTime?
                if (lo_TargetProperty.PropertyType == typeof(string)
                    && (lo_SourceCol.DataType == typeof(DateTime) || lo_SourceCol.DataType == typeof(DateTime?)))
                {
                    if (DateTime.TryParse(ao_Row[lo_SourceCol.ColumnName].ToString(), out dtTmp))
                    {
                        lo_TargetProperty.SetValue(ao_Target, dtTmp.ToString(GetFormatString.DateEdit), null);
                    }
                    else
                    {
                        lo_TargetProperty.SetValue(ao_Target, null, null);
                    }
                    continue;
                }

                if ((lo_TargetProperty.PropertyType == typeof(TimeSpan) || lo_TargetProperty.PropertyType == typeof(TimeSpan?))
                    && lo_SourceCol.DataType == typeof(string)) //Target type is TimeSpan or TimeSpan?, Source type is string
                {
                    strTmp = ao_Row[lo_SourceCol.ColumnName].ToString();
                    if (TimeSpan.TryParse(strTmp, out tsTmp))
                    {
                        lo_TargetProperty.SetValue(ao_Target, tsTmp, null);
                    }
                    else
                    {
                        lo_TargetProperty.SetValue(ao_Target, null, null);
                    }
                    continue;
                }
                #endregion Special transfer rule

                //Copy value when target type is assignable from source type, 
                if (lo_TargetProperty.PropertyType.IsAssignableFrom(lo_SourceCol.DataType))
                {
                    lo_TargetProperty.SetValue(ao_Target, ao_Row[lo_SourceCol.ColumnName], null);
                }
                else
                {
                    //Target type is NOT assignable from source type, set target value is null
                    lo_TargetProperty.SetValue(ao_Target, null, null);
                }
            }
        }
