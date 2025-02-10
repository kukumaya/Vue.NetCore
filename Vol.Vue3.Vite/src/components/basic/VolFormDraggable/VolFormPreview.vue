<template>
  <div style="padding: 15px 20px 15px 5px">
    <div class="pre-text">{{ text }}</div>
    <vol-form
      ref="form"
      :labelWidth="80"
      :load-key="false"
      :formFields="options.fields"
      :formRules="options.formOptions"
    >
    </vol-form>
    <div class="tables">
      <div
        class="table-item"
        v-for="(item, index) in options.tables"
        :key="index"
      >
        <div class="table-header">
          <div class="header-text">
            {{ item.name }}
          </div>
          
        </div>
        <vol-table
          :url="item.url"
          :load-key="false"
          :index="true"
          :ref="'table' + index"
          :tableData="item.tableData"
          :columns="item.columns"
          :buttons="item.buttons.filter((item)=>item.ck)"
          :max-height="250"
          :pagination-hide="item.pagination"
          :column-index="true"
          :ck="true"
        ></vol-table>
      </div>
    </div>

    <div class="tables" style="padding-bottom: 10px">
      <el-tabs
        v-model="tabsModel"
        v-show="options.tabs.length"
        @tab-click="() => {}"
      >
        <el-tab-pane
          style="padding: 0"
          class="table-item"
          v-for="(item, index) in options.tabs"
          :label="item.name"
          :name="index"
          :key="index"
        >
          <div class="table-header">
          </div>
          <vol-table
            :url="item.url"
            :load-key="false"
            :index="true"
            :ref="'tabsTable' + index"
            :tableData="item.tableData"
            :columns="item.columns"
            :buttons="item.buttons.filter((item)=>item.ck)"
            :max-height="250"
            :pagination-hide="item.pagination"
            :column-index="true"
            :ck="true"
          ></vol-table>
        </el-tab-pane>
      </el-tabs>
    </div>

    <div class="form-btns">
      <el-button type="primary" @click="submit" icon="el-icon-check" size="small"
        >提交</el-button
      >
      <el-button
        type="primary"
        @click="reset"
        plain
        icon="el-icon-refresh-right"
        size="small"
        >重置</el-button
      >
      <el-button
        type="primary"
        @click="download"
        plain
        icon="el-icon-refresh-right"
        size="small"
        >下载代码</el-button
      >
    </div>
  </div>
</template>

<script>
import VolTable from "./../VolTable";
import VolBox from "./../VolBox";
import VolForm from "./../VolForm";
import downloadForm from "./DownloadForm";
export default {
  props: {
    options: {
      type: Object,
      default: () => {
        return { fields: {}, formOptions: [], tables: [], tabs: [] };
      },
    },
  },
  data() {
    return {
      text: "",
      tabsModel: 0,
    };
  },
  created() {},
  methods: {
    tableBtnClick(item, btnIndex, index) {
      if (item.buttons[btnIndex].value == "add") {
        this.$refs["table" + index][0].addRow({});
        return;
      }
      if (item.buttons[btnIndex].value == "del") {
        this.$refs["table" + index][0].delRow();
        return;
      }
    },
    tabsTableBtnClick(item, btnIndex, index) {
      if (item.buttons[btnIndex].value == "add") {
        this.$refs["tabsTable" + index][0].addRow({});
        return;
      }
      if (item.buttons[btnIndex].value == "del") {
        this.$refs["tabsTable" + index][0].delRow();
        return;
      }
    },
    submit() {},
    reset() {
      this.$refs.form.reset();
      this.$Message.success("表单已重置");
    },
    download() {
      downloadForm.call(this);
    },
  },
  components: {
    "vol-table": VolTable,
    "vol-box": VolBox,
    "vol-form": VolForm,
  },
};

VolForm;
</script>
<style lang="less" scoped>
.form-btns {
  text-align: center;
}
.tables {
  padding-left: 15px;
  .table-item {
    padding: 10px;
  }
  .table-header {
    display: flex;
    margin-bottom: 8px;
  }
  .header-text {
    position: relative;
    bottom: -9px;
    flex: 1;
    font-weight: bold;
  }
  .header-btns {
    flex: 1;
    text-align: right;
    margin-right: 2%;
  }
}
</style>