﻿//
// EditContext.cs
//
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using ICSharpCode.NRefactory.TypeSystem;
using MonoDevelop.Ide.TypeSystem;

namespace MonoDevelop.Ide.Editor
{
	public abstract class EditContext : ICSharpCode.NRefactory.AbstractAnnotatable
	{
		public abstract string Name {
			get;
		}

		public abstract Project Project {
			get;
		}

		public abstract IProjectContent ProjectContent {
			get;
		}

		public abstract ICompilation Compilation {
			get;
		}

		public abstract ParsedDocument ParsedDocument {
			get;
		}

		public virtual T GetContent<T> () where T : class
		{
			var t = this as T;
			if (t != null)
				return t;
			return null;
		}

		public event EventHandler DocumentParsed;

		protected void OnDocumentParsed (EventArgs e)
		{
			var handler = DocumentParsed;
			if (handler != null)
				handler (this, e);
		}
	}
}