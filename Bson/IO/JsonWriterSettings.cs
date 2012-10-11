﻿/* Copyright 2010-2012 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Bson.IO
{
    /// <summary>
    /// Represents settings for a JsonWriter.
    /// </summary>
    [Serializable]
    public class JsonWriterSettings : BsonWriterSettings
    {
        // private static fields
        private static JsonWriterSettings __defaults = null; // delay creation to pick up the latest default values

        // private fields
        private bool _closeOutput = false;
        private Encoding _encoding = Encoding.UTF8;
        private bool _indent = false;
        private string _indentChars = "  ";
        private string _newLineChars = "\r\n";
        private JsonOutputMode _outputMode = JsonOutputMode.Shell;
        private Version _shellVersion = new Version(2, 0, 0);
        private bool _useISO8601DateFormat = false;

        // constructors
        /// <summary>
        /// Initializes a new instance of the JsonWriterSettings class.
        /// </summary>
        public JsonWriterSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the JsonWriterSettings class.
        /// </summary>
        /// <param name="closeOutput">Whether to close the output when the writer is closed.</param>
        /// <param name="encoding">The output Encoding.</param>
        /// <param name="guidRepresentation">The representation for Guids.</param>
        /// <param name="indent">Whether to indent the output.</param>
        /// <param name="indentChars">The indentation characters.</param>
        /// <param name="newLineChars">The new line characters.</param>
        /// <param name="outputMode">The output mode.</param>
        /// <param name="shellVersion">The version of the shell to target.</param>
        /// <param name="useISO8601DateFormat">Use the ISO-8601 date format </param>
        public JsonWriterSettings(
            bool closeOutput,
            Encoding encoding,
            GuidRepresentation guidRepresentation,
            bool indent,
            string indentChars,
            string newLineChars,
            JsonOutputMode outputMode,
            Version shellVersion,
            bool useISO8601DateFormat)
            : base(guidRepresentation)
        {
            _closeOutput = closeOutput;
            _encoding = encoding;
            _indent = indent;
            _indentChars = indentChars;
            _newLineChars = newLineChars;
            _outputMode = outputMode;
            _shellVersion = shellVersion;
            _useISO8601DateFormat = useISO8601DateFormat;
        }

        // public static properties
        /// <summary>
        /// Gets or sets the default JsonWriterSettings.
        /// </summary>
        public static JsonWriterSettings Defaults
        {
            get
            {
                if (__defaults == null)
                {
                    __defaults = new JsonWriterSettings();
                }
                return __defaults;
            }
            set { __defaults = value; }
        }

        // public properties
        /// <summary>
        /// Gets or sets whether to close the output when the writer is closed.
        /// </summary>
        public bool CloseOutput
        {
            get { return _closeOutput; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _closeOutput = value;
            }
        }

        /// <summary>
        /// Gets or sets the output Encoding.
        /// </summary>
        public Encoding Encoding
        {
            get { return _encoding; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _encoding = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to indent the output.
        /// </summary>
        public bool Indent
        {
            get { return _indent; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _indent = value;
            }
        }

        /// <summary>
        /// Gets or sets the indent characters.
        /// </summary>
        public string IndentChars
        {
            get { return _indentChars; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _indentChars = value;
            }
        }

        /// <summary>
        /// Gets or sets the new line characters.
        /// </summary>
        public string NewLineChars
        {
            get { return _newLineChars; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _newLineChars = value;
            }
        }

        /// <summary>
        /// Gets or sets the output mode.
        /// </summary>
        public JsonOutputMode OutputMode
        {
            get { return _outputMode; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _outputMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the shell version (used with OutputMode Shell).
        /// </summary>
        public Version ShellVersion
        {
            get { return _shellVersion; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _shellVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets if the datest should be parsed in ISO-8601 format
        /// </summary>
        public bool UseIso8601DateFormat
        {
            get { return _useISO8601DateFormat; }
            set
            {
                if (IsFrozen) { throw new InvalidOperationException("JsonWriterSettings is frozen."); }
                _useISO8601DateFormat = value;
            }
        }

        // public methods
        /// <summary>
        /// Creates a clone of the settings.
        /// </summary>
        /// <returns>A clone of the settings.</returns>
        public new JsonWriterSettings Clone()
        {
            return (JsonWriterSettings)CloneImplementation();
        }

        // protected methods
        /// <summary>
        /// Creates a clone of the settings.
        /// </summary>
        /// <returns>A clone of the settings.</returns>
        protected override BsonWriterSettings CloneImplementation()
        {
            return new JsonWriterSettings(_closeOutput, _encoding, GuidRepresentation, _indent, _indentChars, _newLineChars, _outputMode, _shellVersion, _useISO8601DateFormat);
        }
    }
}
