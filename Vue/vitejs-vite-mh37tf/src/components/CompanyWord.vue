<template>
  <div class="container">
    <h1>上市公司每月營業收入彙總表</h1>
    <div v-if="loading" class="loading">Loading...</div>
    <div v-else>
      <p>Total Records: {{ totalRecords }}</p>
      <div class="table-container">
        <table>
          <thead>
            <tr>
              <th>Report Date</th>
              <th>Data Date Time</th>
              <th>Co No</th>
              <th>Company Name</th>
              <th>Industry</th>
              <th>Revenue For The Month</th>
              <th>Revenue Last Month</th>
              <th>Revenue For The Month Last Year</th>
              <th>Last Month Change (%)</th>
              <th>Yearly Same Month Change (%)</th>
              <th>Grand Total Revenue For The Month</th>
              <th>Grand Total Revenue Last Year</th>
              <th>Grand Total Prior Period Change</th>
              <th>Remark</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="income in operatingIncome" :key="income.coNo">
              <td>{{ income.reportDate }}</td>
              <td>{{ income.dataDateTime }}</td>
              <td>{{ income.coNo }}</td>
              <td>{{ income.companyName }}</td>
              <td>{{ income.industry }}</td>
              <td>{{ income.revenueForTheMonth }}</td>
              <td>{{ income.revenueLastMonth }}</td>
              <td>{{ income.revenueForTheMonthLastYear }}</td>
              <td>{{ roundToTwoDecimal(income.lastMonthChange) }}</td>
              <td>{{ roundToTwoDecimal(income.yearlySameMonthChange) }}</td>
              <td>{{ income.grandTotalRevenueForTheMonth }}</td>
              <td>{{ income.grandTotalRevenueLastYear }}</td>
              <td>{{ income.grandTotalPriorPeriodChange }}</td>
              <td>{{ income.remark }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed, onMounted } from 'vue';
import apiService from '../services/apiService';

export default defineComponent({
  name: 'OperatingIncome',
  setup() {
    const operatingIncome = ref<any[]>([]);
    const loading = ref(true);

    const totalRecords = computed(() => operatingIncome.value.length);

    const roundToTwoDecimal = (value: number) => {
      return Math.round(value * 100) / 100;
    };

    const fetchData = async () => {
      try {
        const data = await apiService.getListedCompanyRevenue();
        operatingIncome.value = data;
      } catch (error) {
        console.error('Error fetching data', error);
      } finally {
        loading.value = false;
      }
    };

    onMounted(() => {
      fetchData();
    });

    return {
      operatingIncome,
      loading,
      totalRecords,
      roundToTwoDecimal,
    };
  },
});
</script>

<style scoped>
.container {
  padding: 20px;
  font-family: Arial, sans-serif;
}

h1 {
  margin: 0;
  padding: 20px 0;
  color: #2c3e50;
  text-align: center;
}

.loading {
  font-size: 1.5em;
  color: #2c3e50;
  text-align: center;
}

p {
  font-size: 1.2em;
  margin-bottom: 10px;
  color: #2c3e50;
  text-align: center;
}

.table-container {
  overflow-x: auto;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}

th {
  background-color: #ecf0f1;
}

tr:nth-child(even) {
  background-color: #f2f2f2;
}

tr:hover {
  background-color: #e0e0e0;
}
</style>
