using System;
using UnityEngine;
using System.Linq;
using LibGit2Sharp;

namespace UniTEAM {

	public class HistoryWindow {

		private static Vector2 scroll;
		private static Vector2 commitMessageScroll = new Vector2();
		private static string commitMessage = string.Empty;
		public static Rect rect;
		public static Rect commitMessageRect;

		public static void draw( Console console, int id ) {
			scroll = GUILayout.BeginScrollView( scroll );

			//if ( console.commitsOnServer.Any() ) {
			foreach ( Commit commit in console.repo.Commits ) {
				try {
					console.getUpdateItem( commit, commit.Parents.First(), rect, onCommitSelected );
				}
				catch {
					console.getUpdateItem( commit, commit, rect, onCommitSelected );
				}
			}
			//}

			GUILayout.EndScrollView();
		}

		public static void commitMessageWindow( int id ) {
			GUIStyle skin = new GUIStyle(GUI.skin.textArea);
			skin.normal.background = GUI.skin.label.normal.background;

			commitMessageScroll = GUILayout.BeginScrollView( commitMessageScroll );
			GUILayout.TextArea(commitMessage, skin);
			GUILayout.EndScrollView();
		}

		private static void onCommitSelected( Commit commit ) {
			commitMessage = commit.Message;
		}
	}
}
