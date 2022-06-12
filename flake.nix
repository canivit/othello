{
  description = "othello";

  outputs = { self, nixpkgs }: let
    pkgs = import nixpkgs {
      system = "x86_64-linux";
    };
  in {
    devShell.x86_64-linux = pkgs.mkShell {
      name = "othello";
      buildInputs = with pkgs; [
        dotnet-sdk_6
      ];
    };
  };
}
