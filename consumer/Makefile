
.PHONY: all clean copymono

all: consumer

MANAGED_DIR=../bin/Debug/net6.0
PUBLISH_DIR=$(MANAGED_DIR)/osx-x64/publish
HOST_DIR=./host

R=$(HOME)/work/dotnet-runtime/runtime/artifacts/bin/mono/OSX.x64.Release

copymono:
	cp $(R)/libmono-component-* $(HOST_DIR)
	cp $(R)/libcoreclr.dylib* $(HOST_DIR)
	cp $(R)/System.Private.CoreLib.dll $(HOST_DIR)


$(HOST_DIR)/.touch-prepare-host: $(MANAGED_DIR)/dnne_sampleNE.dylib $(PUBLISH_DIR)/dnne_sample.runtimeconfig.json $(PUBLISH_DIR)/dnne_sample.deps.json $(PUBLISH_DIR)/*.dll $(PUBLISH_DIR)/*.dylib
	mkdir -p ./host
	cp $(MANAGED_DIR)/dnne_sampleNE.dylib $(HOST_DIR)/libdnne_sampleNE.dylib
	cp $(PUBLISH_DIR)/*.dylib $(HOST_DIR)
	install_name_tool -id libdnne_sampleNE.dylib $(HOST_DIR)/libdnne_sampleNE.dylib
	cp $(PUBLISH_DIR)/*.dll $(HOST_DIR)
	cp $(PUBLISH_DIR)/dnne_sample.deps.json $(HOST_DIR)
	cp $(PUBLISH_DIR)/dnne_sample.runtimeconfig.json $(HOST_DIR)
	touch $@

consumer: main.c $(HOST_DIR)/.touch-prepare-host
	clang -o consumer main.c -I$(MANAGED_DIR) -L$(HOST_DIR) -ldnne_sampleNE
	install_name_tool -change libdnne_sampleNE.dylib @executable_path/host/libdnne_sampleNE.dylib ./consumer

clean:
	-rm -rf consumer $(HOST_DIR)
