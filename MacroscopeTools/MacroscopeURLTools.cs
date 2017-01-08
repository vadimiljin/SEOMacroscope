﻿/*
	
	This file is part of SEOMacroscope.
	
	Copyright 2017 Jason Holland.
	
	The GitHub repository may be found at:
	
		https://github.com/nazuke/SEOMacroscope
	
	Foobar is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.
	
	Foobar is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.
	
	You should have received a copy of the GNU General Public License
	along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Text.RegularExpressions;

namespace SEOMacroscope
{

	public class MacroscopeURLTools : Macroscope
	{

		/**************************************************************************/

		static Macroscope ms = new Macroscope ();
		
		/**************************************************************************/

		public MacroscopeURLTools ()
		{
		}

		/**************************************************************************/

		public static string MakeUrlAbsolute ( string sBaseURL, string sURL )
		{

			string sURLFixed;
			Uri uBase = new Uri ( sBaseURL, UriKind.Absolute );
			Uri uNew = null;

			Regex reDoubleSlash = new Regex ( "^//" );
			Regex reSlash = new Regex ( "^/" );
			Regex reQuery = new Regex ( "^\\?" );
			Regex reHash = new Regex ( "^#" );
			Regex reHTTP = new Regex ( "^http" );
			Regex reUnsupportedScheme = new Regex ( "^[a-z0-9]+:" );
			
			if( reDoubleSlash.IsMatch( sURL ) ) {

				try {
					uNew = new Uri (
						string.Format(
							"{0}:{1}",
							uBase.Scheme,
							sURL
						),
						UriKind.Absolute
					);
			   	
				} catch( InvalidOperationException ex ) {
					ms.debug_msg( ex.Message );
				} catch( UriFormatException ex ) {
					ms.debug_msg( ex.Message );
				}

			} else if( reSlash.IsMatch( sURL ) ) {

				try {
					uNew = new Uri (
						string.Format(
							"{0}://{1}{2}",
							uBase.Scheme,
							uBase.Host,
							sURL
						),
						UriKind.Absolute
					);
			   	
				} catch( InvalidOperationException ex ) {
					ms.debug_msg( ex.Message );
				} catch( UriFormatException ex ) {
					ms.debug_msg( ex.Message );
				}
				
			} else if( reQuery.IsMatch( sURL ) ) {

				try {
					uNew = new Uri (
						string.Format(
							"{0}://{1}{2}",
							uBase.Scheme,
							uBase.Host,
							sURL
						),
						UriKind.Absolute
					);
			   	
				} catch( InvalidOperationException ex ) {
					ms.debug_msg( ex.Message );
				} catch( UriFormatException ex ) {
					ms.debug_msg( ex.Message );
				}

			} else if( reHash.IsMatch( sURL ) ) {

				string sNewURL = sURL.ToString();
				Regex reHashRemove = new Regex ( "#.*$", RegexOptions.Singleline );
				sNewURL = reHashRemove.Replace( sNewURL, "" );

				try {
					uNew = new Uri (
						string.Format(
							"{0}://{1}{2}",
							uBase.Scheme,
							uBase.Host,
							sNewURL
						),
						UriKind.Absolute
					);
			   	
				} catch( InvalidOperationException ex ) {
					ms.debug_msg( ex.Message );
				} catch( UriFormatException ex ) {
					ms.debug_msg( ex.Message );
				}

			} else if( reHTTP.IsMatch( sURL ) ) {

				try {
					uNew = new Uri ( sURL, UriKind.Absolute );
				} catch( InvalidOperationException ex ) {
					ms.debug_msg( ex.Message );
				} catch( UriFormatException ex ) {
					ms.debug_msg( ex.Message );
				}

			} else if( reUnsupportedScheme.IsMatch( sURL ) ) {

				; // NO-OP, for now.

			} else {

				
				ms.debug_msg( string.Format( "RELATIVE URL 1: {0}", sURL ) );

				string sBasePath = Regex.Replace( uBase.AbsolutePath, "/[^/]+$", "/" );
				string sNewPath = string.Join( "", sBasePath, sURL );
				
				ms.debug_msg( string.Format( "RELATIVE URL 2: {0}", sBasePath ) );
				ms.debug_msg( string.Format( "RELATIVE URL 3: {0}", sNewPath ) );
				
				
				try {
					uNew = new Uri (
						string.Format(
							"{0}://{1}{2}",
							uBase.Scheme,
							uBase.Host,
							sNewPath
						),
						UriKind.Absolute
					);
			   	
				} catch( InvalidOperationException ex ) {
					ms.debug_msg( ex.Message );
				} catch( UriFormatException ex ) {
					ms.debug_msg( ex.Message );
				}

			}

			if( uNew != null ) {
				sURLFixed = uNew.ToString();
			} else {
				sURLFixed = sURL;
			}

			return( sURLFixed );

		}

		/**************************************************************************/

		public static Boolean VerifySameHost ( string sBaseURL, string sURL )
		{
			Boolean bSuccess = false;
			Uri uBase = null;
			Uri uNew = null;

			try {
				uBase = new Uri ( sBaseURL, UriKind.Absolute );
			} catch( InvalidOperationException ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sBaseURL ) );
			} catch( UriFormatException ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sBaseURL ) );
			} catch( Exception ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sBaseURL ) );
			}

			try {
				uNew = new Uri ( sURL, UriKind.Absolute );
			} catch( InvalidOperationException ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sURL ) );
			} catch( UriFormatException ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sURL ) );
			} catch( Exception ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sURL ) );
			}

			try {
				if( ( uBase != null ) && ( uNew != null ) && ( uBase.Host.ToString() == uNew.Host.ToString() ) ) {
					bSuccess = true;
				}
			} catch( UriFormatException ex ) {
				ms.debug_msg( ex.Message );
				ms.debug_msg( string.Format( "FAILED TO VERIFY: {0}", sURL ) );
			}
			
			return( bSuccess );
		}

		/**************************************************************************/

		public static int FindUrlDepth ( string sURL )
		{
			
			int iDepth = 0;
			Uri uURI = null;

			try {
				uURI = new Uri ( sURL, UriKind.Absolute );
			} catch( InvalidOperationException ex ) {
				ms.debug_msg( ex.Message );
			} catch( UriFormatException ex ) {
				ms.debug_msg( ex.Message );
			}

			if( uURI != null ) {
				string sPath = uURI.AbsolutePath;
				iDepth = sPath.Split( '/' ).Length - 1;
			}

			return( iDepth );
			
		}

		/**************************************************************************/

		public static string CleanUrlCss ( string sURL )
		{
			
			string sCleaned = sURL;

			sCleaned = Regex.Replace( sCleaned, "^[\\s]", "" );
			sCleaned = Regex.Replace( sCleaned, "[\\s]$", "" );
			sCleaned = Regex.Replace( sCleaned, "^url\\(", "" );
			sCleaned = Regex.Replace( sCleaned, "\\)$", "" );

			return( sCleaned );

		}

		/**************************************************************************/
	}
	
}
