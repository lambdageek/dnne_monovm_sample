
.PHONY: all clean

all: consumer

MANAGED_DIR=../bin/Debug/net6.0

libdnne_sampleNE.dylib: $(MANAGED_DIR)/dnne_sampleNE.dylib
	cp $< $@ 
	install_name_tool -id libdnne_sampleNE.dylib ./libdnne_sampleNE.dylib

dnne_sample.runtimeconfig.json: $(MANAGED_DIR)/dnne_sample.runtimeconfig.json
	cp $< $@

dnne_sample.dll: $(MANAGED_DIR)/dnne_sample.dll
	cp $< $@

consumer: main.c libdnne_sampleNE.dylib dnne_sample.dll dnne_sample.runtimeconfig.json
	clang -o consumer main.c -I$(MANAGED_DIR) -L. -ldnne_sampleNE

clean:
	-rm -f consumer libdnne_sampleNE.dylib dnne_sample.dll dnne_sample.runtimeconfig.json
