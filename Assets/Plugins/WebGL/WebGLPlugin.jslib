mergeInto(LibraryManager.library, {
    LogToConsole: function (message) {
      ReactUnityWebGL.GameOver(Pointer_stringify(message));
    },
  });